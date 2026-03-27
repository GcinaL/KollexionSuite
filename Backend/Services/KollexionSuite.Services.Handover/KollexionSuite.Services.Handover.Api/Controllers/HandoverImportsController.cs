using KollexionSuite.Services.Handover.Application.DTOs;
using KollexionSuite.Services.Handover.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace KollexionSuite.Services.Handover.Api.Controllers
{
    [Route("api/handover/imports")]
    [ApiController]
    public class HandoverImportsController : ControllerBase
    {
        private readonly IFileManagerClient _fileManagerClient;
        private readonly HttpClient _downloader;
        private readonly IHandoverImportService _importService;

        public HandoverImportsController(IFileManagerClient fileManagerClient, IHttpClientFactory httpClientFactory, IHandoverImportService importService)
        {
            _fileManagerClient = fileManagerClient;
            _downloader = httpClientFactory.CreateClient("FileDownloader");
            _importService = importService;
        }

        [HttpPost("{templateId:guid}")]
        [RequestSizeLimit(50_000_000)]
        public async Task<ActionResult<ImportResultDto>> ImportFile(Guid templateId, IFormFile file, CancellationToken ct)
        {
            if (file == null || file.Length == 0)
                return BadRequest("A valid file is required.");

            using var stream = file.OpenReadStream();

            var fileRecord = await _fileManagerClient.UploadAsync(stream, file.FileName, "Handover import file", ct);

            if (fileRecord == null)
                return StatusCode(500, "File upload failed.");

            var downloadedStream = await _downloader.GetStreamAsync(fileRecord.Url, ct);

            var result = await _importService.ImportAsync(templateId, downloadedStream, fileRecord.FileName, ct);

            return Ok(result);
        }
    }
}
