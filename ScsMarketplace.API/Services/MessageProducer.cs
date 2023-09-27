using System;
using System.Text;
using System.Text.Json;
using RabbitMQ.Client;
using ScsMarketplace.API.Models;

namespace ScsMarketplace.API.Services
{
    public class MessageProducer : IMessageProducer
    {
        private readonly ILogger<ExampleModel> _logger;
        private readonly IConfiguration _configuration;
        public MessageProducer(ILogger<ExampleModel> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        public void SendingMessage<T>(T message)
        {
            var factory = new ConnectionFactory()
            {
                HostName = _configuration.GetSection("RabbitMQ").GetValue<string>("Host"),
                UserName = _configuration.GetSection("RabbitMQ").GetValue<string>("User"),
                Password = _configuration.GetSection("RabbitMQ").GetValue<string>("Password")
            };

            var connection = factory.CreateConnection();

            using var channel = connection.CreateModel();


            var jsonString = JsonSerializer.Serialize(message);
            var body = Encoding.UTF8.GetBytes(jsonString);
            try
            {
                channel.ExchangeDeclare("basicExchange", ExchangeType.Topic, true, false);
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, "Exchange already declared");
            }


            channel.BasicPublish("basicExchange", "create.user", body: body);
        }
    }
}
