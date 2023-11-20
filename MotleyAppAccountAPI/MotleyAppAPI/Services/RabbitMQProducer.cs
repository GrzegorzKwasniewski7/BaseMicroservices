using MotleyApp.Domain.Entities;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace MotleyAppAPI.Services
{
    public class RabbitMQProducer : IMessageProducer
    {
        public void SendMessage<T>(T message)
        {
            var factory = new ConnectionFactory { HostName = "localhost", Password = "ZEppelin34567%", UserName = "gkwasniewski",
                Uri = new Uri("amqps://b-0ed699be-aff8-4810-b9b5-b206d124a741.mq.eu-north-1.amazonaws.com:5671")
            };
            
            var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();
            channel.QueueDeclare("orders", durable: true, exclusive: false, autoDelete: false);
            var json = JsonConvert.SerializeObject(message);
            var body = Encoding.UTF8.GetBytes(json);

            channel.BasicPublish(exchange: "", routingKey: "orders", body: body);
        }
    }
}
