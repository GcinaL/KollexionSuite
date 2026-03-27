using KollexionSuite.Services.Debtors.Application.DTOs;
using KollexionSuite.Services.Debtors.Application.Interfaces;
using KollexionSuite.Services.Shared.MessageBroker.Abstractions;
using KollexionSuite.Services.Shared.Workflows.Models.Events;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace KollexionSuite.Services.Debtors.Api.Controllers
{
    [Route("api/debtors/workflow")]
    [ApiController]
    public class DebtorsWorkflowController : ControllerBase
    {
        private readonly IMessageBrokerClient _broker;
        private readonly IDebtorService _service;
        public DebtorsWorkflowController(IDebtorService service, IMessageBrokerClient broker)
        {
            _service = service;
            _broker = broker;
        }

        [HttpPost]
        public async Task<IActionResult> BulkCreateDebtors([FromBody] WorkflowStepRequestedEvent evt, CancellationToken ct = default)
        {
            var actor = User?.Identity?.Name ?? "system";

            if(evt.PayloadJson == null) return BadRequest("PayloadJson is required.");

            var rows = JsonSerializer.Deserialize<List<CreateDebtorDto>>(evt.PayloadJson);

            var debtors = new List<DebtorDto>();

            if (rows == null) return BadRequest("Invalid PayloadJson.");

            foreach (var row in rows)
            {
                var dto = await _service.AddAsync(row, actor, ct);
                debtors.Add(dto);
            }

            var result = new WorkflowStepResultEvent
            {
                WorkflowInstanceId = evt.WorkflowInstanceId,
                StepInstanceId = evt.StepInstanceId,
                StepName = evt.StepName,
                CorrelationId = evt.CorrelationId,
                Success = true,
                ResultPayloadJson = JsonSerializer.Serialize(debtors)
            };

            await _broker.PublishAsync("workflow.step.results", evt.CorrelationId, JsonSerializer.Serialize(result));

            return Ok();
        }
    }
}
