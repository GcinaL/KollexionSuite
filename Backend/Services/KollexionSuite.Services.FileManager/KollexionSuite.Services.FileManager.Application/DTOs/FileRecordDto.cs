namespace KollexionSuite.Services.FileManager.Application.DTOs
{
    public class FileRecordDto
    {
        public Guid FileId { get; set; }
        public string FileName { get; set; } = string.Empty;
        public string FileDescription { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
        public DateTime UploadedAt { get; set; }
        public Guid? LinkedEntityId { get; set; }
    }
}
