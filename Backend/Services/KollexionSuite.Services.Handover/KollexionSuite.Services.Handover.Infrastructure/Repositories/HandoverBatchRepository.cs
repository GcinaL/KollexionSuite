using KollexionSuite.Services.Handover.Domain.Entities;
using KollexionSuite.Services.Handover.Domain.IRepositories;
using KollexionSuite.Services.Handover.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace KollexionSuite.Services.Handover.Infrastructure.Repositories
{
    public class BatchRepository : IBatchRepository
    {
        private readonly HandoverDbContext _context;

        public BatchRepository(HandoverDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(HandoverBatch batch, CancellationToken ct)
        {
            await _context.Batches.AddAsync(batch, ct);
        }

        public Task<HandoverBatch?> GetByIdAsync(Guid id, CancellationToken ct)
        {
            return _context.Batches
                .Include(b => b.Records)
                .SingleOrDefaultAsync(b => b.BatchId == id, ct);
        }

        public async Task SaveChangesAsync(CancellationToken ct)
        {
            await _context.SaveChangesAsync(ct);
        }
    }
}
