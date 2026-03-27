using KollexionSuite.Services.Handover.Domain.Entities;
using KollexionSuite.Services.Handover.Domain.IRepositories;
using KollexionSuite.Services.Handover.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace KollexionSuite.Services.Handover.Infrastructure.Repositories
{
    public class TemplateRepository : ITemplateRepository
    {
        private readonly HandoverDbContext _context;

        public TemplateRepository(HandoverDbContext context)
        {
            _context = context;
        }

        public async Task<Template?> GetByIdAsync(Guid id, CancellationToken ct)
        {
            return await _context.Templates
                .Include(t => t.Columns)
                .SingleOrDefaultAsync(t => t.TemplateId == id, ct);
        }

        public async Task<Template?> GetByNameAsync(string name, CancellationToken ct)
        {
            return await _context.Templates
                .Include(t => t.Columns)
                .SingleOrDefaultAsync(t => t.Name == name, ct);
        }

        public async Task AddAsync(Template template, CancellationToken ct)
        {
            await _context.Templates.AddAsync(template, ct);
            await _context.SaveChangesAsync(ct);
        }

        public async Task UpdateAsync(Template template, CancellationToken ct)
        {
            _context.Templates.Update(template);
            await _context.SaveChangesAsync(ct);
        }
    }

    
}
