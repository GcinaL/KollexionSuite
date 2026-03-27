using KollexionSuite.Services.Handover.Domain.Entities;

namespace KollexionSuite.Services.Handover.Domain.IRepositories
{
    public interface IBatchRepository
    {
        Task AddAsync(HandoverBatch batch, CancellationToken ct);
        Task SaveChangesAsync(CancellationToken ct);
    }
}
