using KollexionSuite.Services.Auditing.Application.Interfaces;
using KollexionSuite.Services.Shared.Audit.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KollexionSuite.Services.Auditing.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuditsController : ControllerBase
    {
        private readonly IAuditService _service;
        public AuditsController(IAuditService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken = default)
        {
            var records = await _service.GetAllAsync(cancellationToken);
            return Ok(records);
        }

        [HttpPost]
        public async Task<IActionResult> AddEvent([FromBody] CreateAuditDto dto, CancellationToken cancellationToken = default)
        {
            var result = await _service.AddAsync(dto, cancellationToken);
            return CreatedAtAction(nameof(GetEvent), new { id = result.EventId }, result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEvent(Guid id, CancellationToken cancellationToken = default)
        {
            var record = await _service.GetByIdAsync(id, cancellationToken);
            return Ok(record);
        }
    }
}
