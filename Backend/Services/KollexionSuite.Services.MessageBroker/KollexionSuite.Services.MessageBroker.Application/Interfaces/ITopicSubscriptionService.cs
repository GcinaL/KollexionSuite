using KollexionSuite.Services.MessageBroker.Application.Contracts.Requests;
using KollexionSuite.Services.MessageBroker.Application.Contracts.Responses;

namespace KollexionSuite.Services.MessageBroker.Application.Interfaces
{
    public interface ITopicSubscriptionService
    {
        Task<TopicSubscriptionResponse> CreateAsync(TopicSubscriptionRequest request, CancellationToken cancellationToken = default);

        Task<TopicSubscriptionResponse?> GetAsync(Guid id, CancellationToken cancellationToken = default);

        Task<IReadOnlyList<TopicSubscriptionResponse>> GetAllAsync(CancellationToken cancellationToken = default);

        Task<TopicSubscriptionResponse?> UpdateAsync(Guid id, TopicSubscriptionRequest request, CancellationToken cancellationToken = default);

        Task<bool> DeactivateAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
