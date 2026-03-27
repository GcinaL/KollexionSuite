using DebtCollection.Services.Debtors.Infrastructure.Data;
using KollexionSuite.Services.Debtors.Domain.Entities;
using KollexionSuite.Services.Debtors.Domain.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace KollexionSuite.Services.Debtors.Infrastructure.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly DebtorDbContext _context;

        public ContactRepository(DebtorDbContext context)
        {
            _context = context;
        }

        public async Task<Contact?> GetByIdAsync(Guid contactId, CancellationToken ct)
        {
            return await _context.Contacts
                .FirstOrDefaultAsync(c => c.ContactId == contactId, ct);
        }

        public async Task AddAsync(Contact contact, CancellationToken ct)
        {
            await _context.Contacts.AddAsync(contact, ct);
            await _context.SaveChangesAsync(ct);
        }

        public async Task UpdateAsync(Contact contact, CancellationToken ct)
        {
            _context.Contacts.Update(contact);
            await _context.SaveChangesAsync(ct);
        }
    }
}
