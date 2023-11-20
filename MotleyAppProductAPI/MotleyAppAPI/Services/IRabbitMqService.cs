using RabbitMQ.Client;

namespace MotleyAppAPI.Services
{
    public interface IRabbitMqService
    {
        IConnection CreateChannel();
    }
}
