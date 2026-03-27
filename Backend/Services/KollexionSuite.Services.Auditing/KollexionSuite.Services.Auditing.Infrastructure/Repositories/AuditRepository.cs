using DebtCollection.Services.Auditing.Entities;
using DebtCollection.Services.Auditing.Infrastructure.Data;
using DebtCollection.Services.Auditing.IRepositories;

namespace DebtCollection.Services.Auditing.Repositories
{
    public class AuditRepository : IAuditRepository
    {
        private readonly AuditDbContext _context;

        public AuditRepository(AuditDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AuditEvent>> GetAllAsync(CancellationToken ct)
        {
            return _context.AuditEvents.AsEnumerable();
        }
        public async Task<AuditEvent?> GetByIdAsync(Guid id, CancellationToken ct)
        {
            return await _context.AuditEvents.FindAsync(id , ct);
        }
        public async Task AddAsync(AuditEvent audit, CancellationToken ct)
        {
            await _context.AuditEvents.AddAsync(audit, ct);

            await _context.SaveChangesAsync(ct);
        }
    }
}
