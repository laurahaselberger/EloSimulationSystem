using ProjectClassLibrary.Entities;
using ProjectClassLibrary.Entities.Enums;
using RabbitMQ.Client;
namespace ProjectClassLibrary.Configuration;
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
    }
    public void ChangeState(EProjectState state, AProject project) {
        project.ProjectState = state;
    }
}