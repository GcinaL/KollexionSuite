namespace KollexionSuite.Services.Workflows.Application.Interfaces
{
    public interface IMessageBrokerClient
    {
        Task PublishAsync(string topic, string key, string messageJson, CancellationToken cancellationToken = default);
    }
}
