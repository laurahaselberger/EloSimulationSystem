using System.Text;
using ProjectClassLibrary.Configuration;
using ProjectClassLibrary.Entities.DTO;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
namespace approval_queue;
public class StatusQueue : Configuration
{
    public StatusQueue() {
        Receiver("approved"); // status.approved
        Receiver("canceled"); // status.canceled
    }
    public void Receiver(string queue) {
        var consumer = new EventingBasicConsumer(channel);
        consumer.Received += (model, ea) =>
        {
            var body = ea.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);
            var routingKey = ea.RoutingKey;
            Console.WriteLine($"Received '{routingKey}':'{message}'");
        };
        channel.BasicConsume(queue: queue,
            autoAck: true,
            consumer: consumer);
    }
}