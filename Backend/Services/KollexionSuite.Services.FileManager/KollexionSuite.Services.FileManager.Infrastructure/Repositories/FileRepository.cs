using KollexionSuite.Services.FileManager.Domain.Entities;
using KollexionSuite.Services.FileManager.Domain.IRepositories;
using KollexionSuite.Services.FileManager.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace KollexionSuite.Services.FileManager.Infrastructure.Repositories
{
    public class FileRepository : IFileRepository
    {
        private readonly FileDbContext _context;

        public FileRepository(FileDbContext context)
        {
            _context = context;
        }

        public async Task<FileRecord?> GetByIdAsync(Guid id, CancellationToken ct)
        {
            return await _context.Files.FirstOrDefaultAsync(f => f.FileId == id, ct);
        }

        public async Task AddAsync(FileRecord file, CancellationToken ct)
        {
            await _context.Files.AddAsync(file, ct);
        }

        public async Task DeleteAsync(FileRecord file, CancellationToken ct)
        {
            if (await GetByIdAsync(file.FileId, ct) == null) return;

            _context.Files.Remove(file);
        }

        public async Task SaveChangesAsync(CancellationToken ct)
        {
            await _context.SaveChangesAsync(ct);
        }
    }
}
