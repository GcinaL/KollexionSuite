using KollexionSuite.Services.FileManager.Application.DTOs;
using KollexionSuite.Services.FileManager.Application.Interfaces;
using KollexionSuite.Services.FileManager.Domain.Entities;
using KollexionSuite.Services.FileManager.Domain.IRepositories;
using KollexionSuite.Services.FileManager.Infrastructure.Storage;

namespace KollexionSuite.Services.FileManager.Application.Services
{
    public class FileService : IFileService
    {
        private readonly IFileRepository _repository;
        private readonly AzureBlobStorageProvider _blobProvider;

        public FileService(IFileRepository repository, AzureBlobStorageProvider blobProvider)
        {
            _repository = repository;
            _blobProvider = blobProvider;
        }

        public async Task<FileUploadResultDto> UploadAsync(FileUploadRequestDto request, CancellationToken ct)
        {
            string blobUrl = await _blobProvider.UploadAsync(
                request.FileName,
                request.FileStream,
                request.ContentType,
                ct);

            var record = new FileRecord
            {
                FileName = request.FileName,
                FileDescription = request.FileDescription,
                FileType = request.ContentType,
                FileSize = request.FileStream.Length,
                StoragePath = blobUrl,
                UploadedBy = request.UploadedBy
            };

            await _repository.AddAsync(record, ct);
            await _repository.SaveChangesAsync(ct);

            return new FileUploadResultDto
            {
                FileId = record.FileId,
                FileName = record.FileName,
                Url = blobUrl
            };
        }

        public async Task<byte[]> ExportAsync(FileExportRequestDto request, CancellationToken ct)
        {
            var sb = new System.Text.StringBuilder();
            var headers = request.Data.First().Keys;
            sb.AppendLine(string.Join(",", headers));

            foreach (var row in request.Data)
                sb.AppendLine(string.Join(",", row.Values));

            return System.Text.Encoding.UTF8.GetBytes(sb.ToString());
        }

        public async Task<FileRecordDto?> GetFileByIdAsync(Guid fileId, CancellationToken ct)
        {
            var file = await _repository.GetByIdAsync(fileId, ct);
            if (file == null) return null;

            return new FileRecordDto
            {
                FileId = file.FileId,
                FileName = file.FileName,
                FileDescription = file.FileDescription,
                UploadedAt = file.UploadedAt,
                Url = $"/api/files/{file.FileId}"
            };
        }

        public async Task DeleteFileAsync(Guid fileId, CancellationToken ct)
        {
            var file = await _repository.GetByIdAsync(fileId, ct);
            if (file == null) return;

            if (File.Exists(file.StoragePath))
                File.Delete(file.StoragePath);

            await _repository.DeleteAsync(file, ct);
            await _repository.SaveChangesAsync(ct);
        }
    }
}