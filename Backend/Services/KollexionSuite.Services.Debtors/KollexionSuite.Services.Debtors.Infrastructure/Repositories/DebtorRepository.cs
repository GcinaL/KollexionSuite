using DebtCollection.Services.Debtors.Infrastructure.Data;
using KollexionSuite.Services.Debtors.Domain.Entities;
using KollexionSuite.Services.Debtors.Domain.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace KollexionSuite.Services.Debtors.Infrastructure.Repositories
{
    public class DebtorRepository : IDebtorRepository
    {
        private readonly DebtorDbContext _context;

        public DebtorRepository(DebtorDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Debtor debtor, CancellationToken ct)
        {
            await _context.Debtors.AddAsync(debtor, ct);
            await _context.SaveChangesAsync(ct);
        }

        public async Task<bool> DeleteAsync(Guid id, CancellationToken ct)
        {
            var existing = await _context.Debtors.FindAsync(id, ct);
            if (existing == null) return false;

            _context.Debtors.Remove(existing);
            await _context.SaveChangesAsync(ct);

            return true;
        }


        public async Task<IEnumerable<Debtor>> GetAllAsync(CancellationToken ct, int page = 1, int pageSize = 50)
        {
            if (page < 1) page = 1;
            if (pageSize < 1) pageSize = 50;

            return await _context.Debtors
                .Include(p => p.Contacts)
                .Include(p => p.Consents)
                .Include(p => p.Identifier)
                .OrderByDescending(p => p.CreatedAt)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync(ct);
        }

        public async Task<Debtor?> GetByIdAsync(Guid id, CancellationToken ct)
        {
            return await _context.Debtors
               .Include(p => p.Contacts)
               .Include(p => p.Consents)
               .Include(p => p.Identifier)
               .FirstOrDefaultAsync(p => p.DebtorId == id, ct);
        }

        public async Task<Debtor?> GetByIdentifierAsync(string type, string value, CancellationToken ct)
        {
            var identifier = await _context.Identifiers
                .AsNoTracking()
                .FirstOrDefaultAsync(i => i.IdentifierType == type && i.IdentifierValue == value, ct);

            if (identifier == null) return null;

            return await GetByIdAsync(identifier.DebtorId, ct);
        }

        public async Task UpdateAsync(Debtor debtor, CancellationToken ct)
        {
            _context.Debtors.Update(debtor);
            await _context.SaveChangesAsync(ct);
        }
    }
}
