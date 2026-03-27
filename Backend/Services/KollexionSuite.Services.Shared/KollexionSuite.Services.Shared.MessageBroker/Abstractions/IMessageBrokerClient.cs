namespace KollexionSuite.Services.Shared.MessageBroker.Abstractions
{
    public interface IMessageBrokerClient
    {
        Task PublishAsync(string topic, string key, string messageJson, CancellationToken cancellationToken = default);
    }
}
