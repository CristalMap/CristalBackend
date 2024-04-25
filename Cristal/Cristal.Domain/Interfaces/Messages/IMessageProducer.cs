namespace Cristal.Domain.Interfaces.Messages
{
    public interface IMessageProducer
    {
        void Send(string message);
    }
}
