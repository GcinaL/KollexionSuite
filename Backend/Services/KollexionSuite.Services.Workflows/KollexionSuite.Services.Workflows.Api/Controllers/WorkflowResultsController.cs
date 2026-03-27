using KollexionSuite.Services.Shared.Workflows.Models.Events;
using KollexionSuite.Services.Workflows.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace KollexionSuite.Services.Workflows.Api.Controllers
{
    [ApiController]
    [Route("api/workflows/results")]
    public class WorkflowResultsController : ControllerBase
    {
        private readonly IWorkflowOrchestratorService _orchestratorService;

        public WorkflowResultsController(IWorkflowOrchestratorService orchestratorService)
        {
            _orchestratorService = orchestratorService;
        }

        [HttpPost]
        public async Task<IActionResult> ReceiveResult([FromBody] WorkflowStepResultEvent resultEvent,CancellationToken cancellationToken)
        {
            await _orchestratorService.HandleStepResultAsync(resultEvent, cancellationToken);
            return Ok(new { status = "Received" });
        }
    }
}
