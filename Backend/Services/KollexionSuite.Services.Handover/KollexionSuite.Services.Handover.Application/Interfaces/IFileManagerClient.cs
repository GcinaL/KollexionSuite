using KollexionSuite.Services.Shared.FileManager.Models.DTOs;

namespace KollexionSuite.Services.Handover.Application.Interfaces
{
    public interface IFileManagerClient
    {
        Task<FileRecordDto?> UploadAsync(Stream fileStream, string fileName,string description, CancellationToken ct);

        Task<FileRecordDto?> GetFileAsync(Guid fileId, CancellationToken ct);
    }
}
