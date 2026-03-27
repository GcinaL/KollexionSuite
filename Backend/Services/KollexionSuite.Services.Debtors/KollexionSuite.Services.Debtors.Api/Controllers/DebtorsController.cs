using KollexionSuite.Services.Debtors.Application.DTOs;
using KollexionSuite.Services.Debtors.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace KollexionSuite.Services.Debtors.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DebtorsController : ControllerBase
    {
        private readonly IDebtorService _service;
        public DebtorsController(IDebtorService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken ct, [FromQuery] int page = 1, [FromQuery] int pageSize = 50)
        {
            var list = await _service.GetAllAsync(ct, page, pageSize);
            return Ok(list);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetDebtorById(Guid id, CancellationToken ct)
        {
            var result = await _service.GetByIdAsync(id, ct);
            return Ok(result);
        }

        [HttpGet("identifier/{type}/{value}")]
        public async Task<IActionResult> GetByIdentifier(string type,string value,CancellationToken ct)
        {
            var result = await _service.GetByIdentifierAsync(type, value, ct);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDebtor([FromBody] CreateDebtorDto dto, CancellationToken ct)
        {
            var actor = User?.Identity?.Name ?? "system";

            var result = await _service.AddAsync(dto, actor, ct);
            return CreatedAtAction(nameof(GetDebtorById), new { id = result.DebtorId }, result);
        }

        [HttpPost("{debtorId:guid}/contacts")]
        public async Task<IActionResult> AddContact(Guid debtorId,[FromBody] CreateContactDto dto, CancellationToken ct)
        {
            var actor = User?.Identity?.Name ?? "system";

            var result = await _service.AddContactAsync(debtorId, dto, actor, ct);

            return CreatedAtAction(nameof(GetContactById), new { contactId = result.ContactId }, result);
        }

        [HttpGet("contacts/{contactId:guid}")]
        public async Task<IActionResult> GetContactById(Guid contactId, CancellationToken ct)
        {
            var result = await _service.GetContactByIdAsync(contactId, ct);
            return Ok(result);
        }

        [HttpPut("contacts/{contactId:guid}")]
        public async Task<IActionResult> UpdateContact(Guid contactId,[FromBody] UpdateContactDto dto, CancellationToken ct)
        {
            var actor = User?.Identity?.Name ?? "system";

            var result = await _service.UpdateContactAsync(contactId, dto, actor, ct);
            return Ok(result);
        }
    }
}
