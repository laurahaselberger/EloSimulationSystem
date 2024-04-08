using System.Text;
using System.Text.Json;
using ProjectClassLibrary.Configuration;
using ProjectClassLibrary.Entities;
using ProjectClassLibrary.Entities.Enums;
using RabbitMQ.Client;

namespace WebApp.Services;

public class SendToFacility : Configuration
{
    public void Publish(ManagementProject project) {
        project.ProjectState = EProjectState.IN_APPROVEMENT;
        string routingKey = "facility." + project.Facility.FacilityName;
        var jsonMessage = JsonSerializer.Serialize(project); // Projekt to JSON
        CreateMessage(routingKey, jsonMessage);
    }
    public void Publish(RequestFundingProject project) {
        project.ProjectState = EProjectState.IN_APPROVEMENT;
        string routingKey = "facility." + project.Facility.FacilityName;
        var jsonMessage = JsonSerializer.Serialize(project);
        CreateMessage(routingKey, jsonMessage);
    }
    
    public void CreateMessage(string routingKey, string jsonMessage) {
        var body = Encoding.UTF8.GetBytes(jsonMessage); // JSON to Byte-Array
        channel.BasicPublish(exchange: "facility",
            routingKey: routingKey,
            basicProperties: null,
            body: body);
        Console.WriteLine($" [x] Sent '{routingKey}':'{jsonMessage}'");
    }
   
}