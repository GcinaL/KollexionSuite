using KollexionSuite.Services.MessageBroker.Domain.IRepositories;
using KollexionSuite.Services.MessageBroker.Domain.Models;
using KollexionSuite.Services.MessageBroker.Domain.Utilities;
using KollexionSuite.Services.MessageBroker.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace KollexionSuite.Services.MessageBroker.Infrastructure.Repositories
{
    public sealed class OutboxEventRepository
    : MessageBrokerRepository<OutboxEvent>, IOutboxEventRepository
    {
        public OutboxEventRepository(MessageBrokerDbContext dbContext) : base(dbContext) { }

        public async Task<IReadOnlyList<OutboxEvent>> GetPendingBatchAsync(int batchSize, CancellationToken cancellationToken = default)
        {
            return await _dbContext.OutboxEvents
                .Where(e => e.Status == OutboxStatus.Pending || e.Status == OutboxStatus.Failed)
                .OrderBy(e => e.CreatedAt)
                .Take(batchSize)
                .ToListAsync(cancellationToken);
        }
    }
}
