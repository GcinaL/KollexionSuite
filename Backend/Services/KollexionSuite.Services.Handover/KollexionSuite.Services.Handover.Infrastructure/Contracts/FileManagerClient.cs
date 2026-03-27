using KollexionSuite.Services.Handover.Application.Interfaces;
using KollexionSuite.Services.Shared.FileManager.Models.DTOs;
using System.Net.Http.Json;

namespace KollexionSuite.Services.Handover.Infrastructure.Contracts
{
    public class FileManagerClient : IFileManagerClient
    {
        private readonly HttpClient _http;

        public FileManagerClient(HttpClient http)
        {
            _http = http;
        }

        public async Task<FileRecordDto?> UploadAsync(Stream fileStream,string fileName, string description,CancellationToken ct)
        {
            using var content = new MultipartFormDataContent();
            content.Add(new StreamContent(fileStream), "file", fileName);
            content.Add(new StringContent(description), "description");

            var response = await _http.PostAsync("/api/files/upload", content, ct);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<FileRecordDto>(cancellationToken: ct);
        }

        public async Task<FileRecordDto?> GetFileAsync(Guid fileId,CancellationToken ct)
        {
            var response = await _http.GetAsync($"/api/files/{fileId}", ct);
            if (!response.IsSuccessStatusCode) return null;

            return await response.Content.ReadFromJsonAsync<FileRecordDto>(cancellationToken: ct);
        }
    }
}
