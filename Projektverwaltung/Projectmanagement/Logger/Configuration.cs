using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Logger;
public class Configuration
{
    public ConnectionFactory Factory = new ();
    public readonly IConnection connection;
    public readonly IModel channel;
    public Configuration() {
        Factory = new ConnectionFactory()
        {
            HostName = "localhost",
            UserName = "rabbit",
            Password = "rabbitpwd"
        };
        connection = Factory.CreateConnection();
        channel = connection.CreateModel();
        Receiver("logger");
    }
    public void Receiver(string queue) {
        var consumer = new EventingBasicConsumer(channel);
        consumer.Received += (model, ea) =>
        {
            var body = ea.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);
            var routingKey = ea.RoutingKey;
            Console.WriteLine($"Received '{routingKey}':'{message}'");
            // Thread.Sleep(2000);
        };
        channel.BasicConsume(queue: queue,
            autoAck: true,
            consumer: consumer);
    }
}