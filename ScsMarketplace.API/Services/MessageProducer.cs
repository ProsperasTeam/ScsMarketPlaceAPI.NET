using System;
using System.Text;
using System.Text.Json;
using RabbitMQ.Client;

namespace ScsMarketplace.API.Services
{
    public class MessageProducer : IMessageProducer
    {
        public void SendingMessage<T>(T message)
        {
            var factory = new ConnectionFactory()
            {
                // test comment
                HostName = "localhost",
                UserName = "user",
                Password = "mypass",
                VirtualHost = "/"
            };

            var connection = factory.CreateConnection();

            using var channel = connection.CreateModel();


            channel.QueueDeclare("testQueue", durable: true, exclusive: false);

            var jsonString = JsonSerializer.Serialize(message);
            var body = Encoding.UTF8.GetBytes(jsonString);

            channel.BasicPublish("", "testQueue", body: body);
        }
    }
}

