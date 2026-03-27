using KollexionSuite.Services.FileManager.Application.DTOs;

namespace KollexionSuite.Services.FileManager.Application.Interfaces
{
    public interface IFileService
    {
        Task<FileUploadResultDto> UploadAsync(FileUploadRequestDto request, CancellationToken ct);
        Task<byte[]> ExportAsync(FileExportRequestDto request, CancellationToken ct);
        Task<FileRecordDto?> GetFileByIdAsync(Guid fileId, CancellationToken ct);
        Task DeleteFileAsync(Guid fileId, CancellationToken ct);
    }
}
