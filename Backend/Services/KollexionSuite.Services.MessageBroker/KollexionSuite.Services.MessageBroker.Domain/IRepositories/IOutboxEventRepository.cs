using KollexionSuite.Services.MessageBroker.Domain.Models;

namespace KollexionSuite.Services.MessageBroker.Domain.IRepositories
{
    public interface IOutboxEventRepository : IMessageBrokerRepository<OutboxEvent>
    {
        Task<IReadOnlyList<OutboxEvent>> GetPendingBatchAsync(int batchSize, CancellationToken cancellationToken = default);
    }
}
