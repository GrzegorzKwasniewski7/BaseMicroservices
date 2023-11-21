using Microsoft.Extensions.Options;
using RabbitMQ.Client;

namespace MotleyAppAPI.Services
{
    public class RabbitMqService: IRabbitMqService
    {
        
        public RabbitMqService()
        {
            
        }
        public IConnection CreateChannel()
        {
            ConnectionFactory connection = new ConnectionFactory()
            {
                HostName = "localhost",
                Password = "***",
                UserName = "***",
                Uri = new Uri("amqps://b-0ed699be-aff8-4810-b9b5-b206d124a741.mq.eu-north-1.amazonaws.com:5671")
            };
            connection.DispatchConsumersAsync = true;
            var channel = connection.CreateConnection();
            return channel;
        }
    }
}
