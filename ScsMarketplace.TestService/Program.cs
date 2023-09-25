using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

Console.WriteLine("Hello Consumer!");

var factory = new ConnectionFactory()
{
    HostName = "http://rabbitmq",
    UserName = "user",
    Password = "mypass",
    VirtualHost = "/"
};

var connection = factory.CreateConnection();

using var channel = connection.CreateModel();


channel.QueueDeclare("testQueue", durable: true, exclusive: false);

var consumer = new EventingBasicConsumer(channel);

consumer.Received += (model, eventArgs) =>
{

    var body = eventArgs.Body.ToArray();
    var message = Encoding.UTF8.GetString(body);

    Console.WriteLine($"A message has been received {message}");
};

channel.BasicConsume("testQueue", true, consumer);

Console.ReadKey();