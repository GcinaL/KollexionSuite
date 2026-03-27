

using DebtCollection.Services.Auditing.Entities;

namespace DebtCollection.Services.Auditing.IRepositories
{
    public interface IAuditRepository
    {
        Task<IEnumerable<AuditEvent>> GetAllAsync(CancellationToken cancellationToken);
        Task<AuditEvent?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task AddAsync(AuditEvent auditEvent, CancellationToken cancellationToken);
    }

}
