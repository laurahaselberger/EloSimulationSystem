using System.Text;
using System.Text.Json;
using ProjectClassLibrary.Configuration;
using ProjectClassLibrary.Entities;
using ProjectClassLibrary.Entities.DTO;
using ProjectClassLibrary.Entities.Enums;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
namespace approval_process;
using System.Diagnostics;
public class FacilityQueue : Configuration
{
    public FacilityQueue() {
        Receiver("chemistry"); // facility.chemistry
        Receiver("maths"); // facility.maths
        Receiver("physics"); // facility.physics
    }
    public void Producer(string status, ManagementProject project) {
         string routingKey = "status." + status;
         var jsonMessage = JsonSerializer.Serialize(project); // to JSON
         CreateMessage(routingKey, jsonMessage);
    }
    public void Producer(string status, RequestFundingProject project) {
        string routingKey = "status." + status;
        Console.WriteLine(status);
        var jsonMessage = JsonSerializer.Serialize(project); // to JSON
        CreateMessage(routingKey, jsonMessage);
    }
    public void CreateMessage(string routingKey, string jsonMessage) {
        var body = Encoding.UTF8.GetBytes(jsonMessage);
        channel.BasicPublish(exchange: "status",
            routingKey: routingKey,
            basicProperties: null,
            body: body);
        Console.WriteLine($"Sent '{routingKey}':'{jsonMessage}'");
    }
    public void Receiver(string queue) {
        var consumer = new EventingBasicConsumer(channel);
        consumer.Received += (model, ea) => {
            var body = ea.Body.ToArray();
            var message = Encoding.UTF8.GetString(body); // Byte-Array to JSON
            var routingKey = ea.RoutingKey;
            string status = CalculateProbability();
            Console.WriteLine($"Received '{routingKey}':'{message}' {queue}");
            if (message.Contains("LawType")) {
                ManagementProject project = JsonSerializer.Deserialize<ManagementProject>(message);
                if (status == "approved") {
                    project.ProjectState = EProjectState.APPROVED;
                }
                else {
                    project.ProjectState = EProjectState.CANCELED;
                }
                Producer(status, project);
            }
            else {
                RequestFundingProject project = JsonSerializer.Deserialize<RequestFundingProject>(message);
                if (status == "approved") {
                    project.ProjectState = EProjectState.APPROVED;
                }
                else {
                    project.ProjectState = EProjectState.CANCELED;
                }
                Producer(status, project);
            }
        };
        channel.BasicConsume(queue: queue,
            autoAck: true,
            consumer: consumer);
    }
    public string CalculateProbability() {
        double acceptanceProbability = 0.8; // 80% 
        string status;
        Random random = new Random();
        double randomNumber = random.NextDouble(); // random number between 0 and 1
        if (randomNumber < acceptanceProbability) {
            status = "approved";
        }
        else {
            status = "canceled";
        }
        return status;
    }
}