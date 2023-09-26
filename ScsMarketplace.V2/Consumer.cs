
using System.Text;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace ScsMarketplace.V2
{
	public class Consumer : BackgroundService
	{
        private readonly ILogger<Consumer> _logger;
        private readonly IConfiguration _configuration;

		public Consumer(ILogger<Consumer> logger, IConfiguration configuration)
		{
            _logger = logger;
            _configuration = configuration;
        }

        protected async override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Starting services");
            var factory = new ConnectionFactory()
            {
                HostName = _configuration.GetSection("RabbitMQ").GetValue<string>("Host"),
                UserName = _configuration.GetSection("RabbitMQ").GetValue<string>("User"),
                Password = _configuration.GetSection("RabbitMQ").GetValue<string>("Password"),
                Port = _configuration.GetSection("RabbitMQ").GetValue<int>("Port")
            };

            var connection = factory.CreateConnection();

            using var channel = connection.CreateModel();


            channel.QueueDeclare("testQueue", durable: true, exclusive: false, autoDelete: false);

            var consumer = new EventingBasicConsumer(channel);

            consumer.Received += (model, eventArgs) =>
            {
                _logger.LogInformation("consuming messages");
                var body = eventArgs.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);

                _logger.LogInformation("A message has been received: ", message);

            };

            channel.BasicConsume("testQueue", true, consumer);

            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(TimeSpan.FromSeconds(1), stoppingToken);
            }
        }
    }
}

