using KollexionSuite.Services.FileManager.Domain.Entities;

namespace KollexionSuite.Services.FileManager.Domain.IRepositories
{
    public interface IFileRepository
    {
        Task<FileRecord?> GetByIdAsync(Guid id, CancellationToken ct);
        Task AddAsync(FileRecord file, CancellationToken ct);
        Task DeleteAsync(FileRecord file, CancellationToken ct);
        Task SaveChangesAsync(CancellationToken ct);
    }
}
