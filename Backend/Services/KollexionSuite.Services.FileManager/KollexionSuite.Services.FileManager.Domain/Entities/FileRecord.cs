namespace KollexionSuite.Services.FileManager.Domain.Entities
{
    public class FileRecord
    {
        public Guid FileId { get; set; } = Guid.NewGuid();
        public string FileName { get; set; } = string.Empty;
        public string FileDescription { get; set; } = string.Empty;
        public string FileType { get; set; } = string.Empty;
        public long FileSize { get; set; }
        public string StoragePath { get; set; } = string.Empty;
        public DateTime UploadedAt { get; set; } = DateTime.UtcNow;
        public string UploadedBy { get; set; } = string.Empty;
        public Guid? LinkedEntityId { get; set; }
    }
}
