using KollexionSuite.Services.FileManager.Application.DTOs;
using KollexionSuite.Services.FileManager.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KollexionSuite.Services.FileManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        private readonly IFileService _fileService;

        public FilesController(IFileService fileService)
        {
            _fileService = fileService;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> Upload([FromForm] FileUploadDto dto, CancellationToken ct = default)
        {
            if (dto.File == null || dto.File.Length == 0)
                return BadRequest("No file uploaded");

            using var stream = dto.File.OpenReadStream();

            var extension = Path.GetExtension(dto.File.FileName);
            var filename = $"{DateTime.UtcNow:yyyyMMdd_HHmmss_fffffff}{extension}";

            var description = dto.Description ?? dto.File.FileName;

            var request = new FileUploadRequestDto
            {
                FileName = filename,
                ContentType = dto.File.ContentType,
                FileDescription = description,
                FileStream = stream,
                UploadedBy = User.Identity?.Name ?? "system"
            };
                
            var result = await _fileService.UploadAsync(request, ct);
            return Ok(result);
        }

        [HttpPost("export")]
        public async Task<IActionResult> Export([FromBody] FileExportRequestDto request, CancellationToken ct = default)
        {
            var bytes = await _fileService.ExportAsync(request, ct);
            return File(bytes, "text/csv", $"{request.FileName}.csv");
        }

        [HttpGet("{fileId}")]
        public async Task<IActionResult> Get(Guid fileId, CancellationToken ct = default)
        {
            var file = await _fileService.GetFileByIdAsync(fileId, ct);
            if (file == null) return NotFound();
            return Ok(file);
        }

        [HttpDelete("{fileId}")]
        public async Task<IActionResult> Delete(Guid fileId, CancellationToken ct = default)
        {
            await _fileService.DeleteFileAsync(fileId, ct);
            return NoContent();
        }

        public class FileUploadDto
        {
            public IFormFile File { get; set; }
            public string? Description { get; set; }
        }

    }
}
