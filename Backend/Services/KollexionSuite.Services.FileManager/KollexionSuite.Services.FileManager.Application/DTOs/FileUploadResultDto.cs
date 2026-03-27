namespace KollexionSuite.Services.FileManager.Application.DTOs
{
    public class FileUploadResultDto
    {
        public Guid FileId { get; set; }
        public string FileName { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
    }
}
