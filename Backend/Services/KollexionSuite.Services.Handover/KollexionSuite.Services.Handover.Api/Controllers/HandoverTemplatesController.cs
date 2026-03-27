using KollexionSuite.Services.Handover.Application.DTOs;
using KollexionSuite.Services.Handover.Application.Interfaces;
using KollexionSuite.Services.Handover.Application.Mappings;
using KollexionSuite.Services.Handover.Application.Services;
using KollexionSuite.Services.Handover.Infrastructure.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace KollexionSuite.Services.Handover.Api.Controllers
{
    [ApiController]
    [Route("api/handover/templates")]
    public class HandoverTemplatesController : ControllerBase
    {
        private readonly IFileManagerClient _fileManagerClient;
        private readonly HttpClient _downloader;
        private readonly ITemplateService _templateService;

        public HandoverTemplatesController(IFileManagerClient fileManagerClient, IHttpClientFactory httpClientFactory, ITemplateService templateService)
        {
            _fileManagerClient = fileManagerClient;
            _downloader = httpClientFactory.CreateClient("FileDownloader");
            _templateService = templateService;
        }

        [HttpPost("upload-file")]
        [RequestSizeLimit(50_000_000)]
        public async Task<ActionResult<TemplatePreviewDto>> UploadTemplateFile(IFormFile file, CancellationToken ct)
        {
            if (file == null || file.Length == 0)
                return BadRequest("Invalid file.");

            using var stream = file.OpenReadStream();

            var fileRecord = await _fileManagerClient.UploadAsync(
                stream,
                file.FileName,
                "Template upload",
                ct);

            if (fileRecord == null)
                return StatusCode(500, "File upload failed.");

            var downloadedStream = await _downloader.GetStreamAsync(fileRecord.Url, ct);
            var fileType = FileTypeHelper.FromFileName(fileRecord.FileName);
            var headers = await _templateService.ExtractColumnsAsync(downloadedStream, fileType, ct);

            return Ok(new TemplatePreviewDto
            {
                FileId = fileRecord.FileId,
                FileName = fileRecord.FileName,
                FileType = fileType.ToString(),
                Columns = headers
            });
        }

        [HttpPost]
        public async Task<ActionResult<TemplateDto>> CreateTemplate([FromBody] CreateTemplateFromFileDto dto, CancellationToken ct)
        {
            var result = await _templateService.CreateTemplateFromFileAsync(dto, ct);
            return CreatedAtAction(nameof(GetTemplate), new { templateId = result.TemplateId }, result);
        }

        [HttpGet("{templateId:guid}")]
        public async Task<ActionResult<TemplateDto>> GetTemplate(Guid templateId, CancellationToken ct)
        {
            var template = await _templateService.GetTemplateAsync(templateId, ct);
            if (template == null) return NotFound();
            return Ok(template);
        }
    }
}
