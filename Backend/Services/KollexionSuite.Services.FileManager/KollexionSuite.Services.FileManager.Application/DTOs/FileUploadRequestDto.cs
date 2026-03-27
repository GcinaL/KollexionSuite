namespace KollexionSuite.Services.FileManager.Application.DTOs
{
    public class FileUploadRequestDto
    {
        public string FileName { get; set; } = string.Empty;
        public Stream FileStream { get; set; } = default!;
        public string FileDescription { get; set; } = string.Empty;
        public string ContentType { get; set; } = string.Empty;
        public string UploadedBy { get; set; } = string.Empty;
        public Guid? LinkedEntityId { get; set; }

    }
   
}
