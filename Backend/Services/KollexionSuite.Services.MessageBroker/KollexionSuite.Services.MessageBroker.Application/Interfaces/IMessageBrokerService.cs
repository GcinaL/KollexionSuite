using KollexionSuite.Services.MessageBroker.Application.Contracts.Requests;

namespace KollexionSuite.Services.MessageBroker.Application.Interfaces
{
    public interface IMessageBrokerService
    {
        Task<Guid> EnqueueAsync(PublishMessageRequest request, CancellationToken cancellationToken = default);
    }
}
