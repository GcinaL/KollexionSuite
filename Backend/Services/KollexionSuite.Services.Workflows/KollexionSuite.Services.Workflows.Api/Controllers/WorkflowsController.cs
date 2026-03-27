using KollexionSuite.Services.Shared.Workflows.Models.Events;
using KollexionSuite.Services.Shared.Workflows.Models.Requests;
using KollexionSuite.Services.Workflows.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace KollexionSuite.Services.Workflows.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkflowsController : ControllerBase
    {
        private readonly IWorkflowOrchestratorService _orchestratorService;

        public WorkflowsController(IWorkflowOrchestratorService orchestratorService)
        {
            _orchestratorService = orchestratorService;
        }

        [HttpPost("definitions")]
        public async Task<IActionResult> RegisterDefinition([FromBody] RegisterWorkflowDefinitionRequest request,CancellationToken cancellationToken)
        {
            var definition = await _orchestratorService.RegisterWorkflowDefinitionAsync(request, cancellationToken);
            return CreatedAtAction(nameof(GetDefinition), new { id = definition.Id }, definition);
        }

        [HttpGet("definitions/{id:guid}")]
        public IActionResult GetDefinition(Guid id)
        {
            // For brevity, you can implement a query service or reuse repository via application
            return Ok(); // TODO: add read model
        }

        [HttpPost("start")]
        public async Task<IActionResult> StartWorkflow([FromBody] StartWorkflowRequest request, CancellationToken cancellationToken)
        {
            var instanceId = await _orchestratorService.StartWorkflowAsync(request, cancellationToken);
            return Ok(new { WorkflowInstanceId = instanceId });
        }

        [HttpPost]
        public async Task<IActionResult> ReceiveResult([FromBody] WorkflowStepResultEvent resultEvent, CancellationToken cancellationToken)
        {
            await _orchestratorService.HandleStepResultAsync(resultEvent, cancellationToken);
            return Ok(new { status = "Received" });
        }
    }
}
