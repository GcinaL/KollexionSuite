using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;

namespace KollexionSuite.Services.FileManager.Infrastructure.Storage
{
    public class AzureBlobStorageProvider
    {
        private readonly BlobServiceClient _blobServiceClient;
        private readonly string _containerName = "uploads";

        public AzureBlobStorageProvider(BlobServiceClient blobServiceClient)
        {
            _blobServiceClient = blobServiceClient;
        }

        public async Task<string> UploadAsync(string fileName, Stream fileStream, string contentType, CancellationToken ct)
        {
            var containerClient = _blobServiceClient.GetBlobContainerClient(_containerName);
            await containerClient.CreateIfNotExistsAsync(PublicAccessType.Blob, cancellationToken: ct);

            var blobClient = containerClient.GetBlobClient(fileName);
            await blobClient.UploadAsync(fileStream, new BlobHttpHeaders { ContentType = contentType }, cancellationToken: ct);

            return blobClient.Uri.ToString();
        }

        public async Task DeleteAsync(string fileName, CancellationToken ct)
        {
            var containerClient = _blobServiceClient.GetBlobContainerClient(_containerName);
            var blobClient = containerClient.GetBlobClient(fileName);
            await blobClient.DeleteIfExistsAsync(DeleteSnapshotsOption.IncludeSnapshots, cancellationToken: ct);
        }
    }
}
