using Cristal.Application.Interfaces;
using Cristal.Application.Services;
using Cristal.Domain.Interfaces.Messages;
using Cristal.Domain.Interfaces.Repositories;
using Cristal.Domain.Interfaces.Services;
using Cristal.Domain.Services;
using Cristal.Infra.Data.Repositories;
using Cristal.Infra.Messages.Consumers;
using Cristal.Infra.Messages.Producers;
using Cristal.Infra.Messages.Settings;
using Cristal.Services.Configurations.Jwt;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

JwtConfiguration.Configure(builder);

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.Configure<RabbitMQSettings>(builder.Configuration.GetSection("RabbitMQSettings"));
builder.Services.Configure<MailSettings>(builder.Configuration.GetSection("MailSettings"));

builder.Services.AddTransient<IMessageProducer, MessageProducer>();
builder.Services.AddTransient<IUsuarioAppService, UsuarioAppService>();
builder.Services.AddTransient<IDenunciaAppService, DenunciaAppService>();
builder.Services.AddTransient<IUsuarioDomainService, UsuarioDomainService>();
builder.Services.AddTransient<IDenunciaDomainService, DenunciaDomainService>();
builder.Services.AddTransient<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddTransient<IDenunciaRepository, DenunciaRepository>();
builder.Services.AddTransient<IEnderecoRepository, EnderecoRepository>();

builder.Services.AddHostedService<MessageConsumer>();

builder.Services.AddCors(
    s => s.AddPolicy("DefaultPolicy", builder =>
    {
        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    })
);

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseCors("DefaultPolicy");
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
