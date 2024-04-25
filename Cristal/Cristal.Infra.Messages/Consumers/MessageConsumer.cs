using Cristal.Domain.DTOs;
using Cristal.Infra.Messages.Settings;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace Cristal.Infra.Messages.Consumers
{
    public class MessageConsumer : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly RabbitMQSettings _rabbitMQSettings;
        private readonly MailSettings _mailSettings;

        private IConnection _connection;
        private IModel _model;

        public MessageConsumer(IServiceProvider serviceProvider, IOptions<RabbitMQSettings> rabbitMQSettings,
            IOptions<MailSettings> mailSettings)
        {
            _serviceProvider = serviceProvider;
            _rabbitMQSettings = rabbitMQSettings.Value;
            _mailSettings = mailSettings.Value;

            var factory = new ConnectionFactory { Uri = new Uri(_rabbitMQSettings.Host) };
            _connection = factory.CreateConnection();
            _model = _connection.CreateModel();

            _model.QueueDeclare(queue: _rabbitMQSettings.Queue, durable: true, exclusive: false,
                autoDelete: false, arguments: null);
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var consumer = new EventingBasicConsumer(_model);

            consumer.Received += (sender, args) =>
            {
                var contentArray = args.Body.ToArray();
                var contentString = Encoding.UTF8.GetString(contentArray);

                var emailMessageDTO = JsonConvert.DeserializeObject<EmailMessageDTO>(contentString);

                using (var scope = _serviceProvider.CreateScope())
                {
                    EnviarEmail(emailMessageDTO);
                    _model.BasicAck(args.DeliveryTag, false);
                }
            };
            _model.BasicConsume(_rabbitMQSettings.Queue, false, consumer);
            return Task.CompletedTask;
        }

        private void EnviarEmail(EmailMessageDTO dto)
        {
            var mailMessage = new MailMessage(_mailSettings.Email, dto.MailTo);

            mailMessage.Subject = dto.Subject;
            mailMessage.Body = dto.Body;
            mailMessage.IsBodyHtml = dto.IsBodyHtml;

            var smtpClient = new SmtpClient(_mailSettings.Smtp, _mailSettings.Port);
            smtpClient.EnableSsl = true;
            smtpClient.Credentials = new NetworkCredential(_mailSettings.Email, _mailSettings.Pass);
            smtpClient.Send(mailMessage);
        }
    }
}
