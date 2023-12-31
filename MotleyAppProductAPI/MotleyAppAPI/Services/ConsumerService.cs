﻿using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using MediatR;
using Newtonsoft.Json;
using MotleyApp.Domain.Entities;
using MotleyApp.Application.Products.Commands;
using MassTransit.Mediator;

namespace MotleyAppAPI.Services
{
    public class ConsumerService : IConsumerService, IDisposable
    {
        private readonly IModel _model;
        private readonly IConnection _connection;
        
        public ConsumerService(IRabbitMqService rabbitMqService)
        {
            
            _connection = rabbitMqService.CreateChannel();
            _model = _connection.CreateModel();
            _model.QueueDeclare(_queueName, durable: true, exclusive: false, autoDelete: false);
            _model.ExchangeDeclare("motleyapp.exchange", ExchangeType.Fanout, durable: true, autoDelete: false);
            _model.QueueBind(_queueName, "motleyapp.exchange", string.Empty);
        }
        const string _queueName = "orders";
        public async Task ReadMessgaes()
        {
            var consumer = new AsyncEventingBasicConsumer(_model);
            consumer.Received += async (ch, ea) =>
            {
                var body = ea.Body.ToArray();
                var text = System.Text.Encoding.UTF8.GetString(body);           
                
                await Task.CompletedTask;
                var orderToComplete = JsonConvert.DeserializeObject<CompleteOrder>(text);
                
                _model.BasicAck(ea.DeliveryTag, false);
            };
            _model.BasicConsume(_queueName, false, consumer);
            await Task.CompletedTask;
        }

        
        public void Dispose()
        {
            if (_model.IsOpen)
                _model.Close();
            if (_connection.IsOpen)
                _connection.Close();
        }
    }
}
