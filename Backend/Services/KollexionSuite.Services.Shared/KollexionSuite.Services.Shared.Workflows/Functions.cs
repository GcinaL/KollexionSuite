using KollexionSuite.Services.Shared.Workflows.Models.Events;
using System.Text.Json;

namespace KollexionSuite.Services.Shared.Workflows
{
    public static class Workflow
    {
        public static WorkflowStepResultEvent GetStepResultEvent(WorkflowStepRequestedEvent workflowStepRequestedEvent, bool isSuccessful, object entity)
        {
            return new WorkflowStepResultEvent
            {
                WorkflowInstanceId = workflowStepRequestedEvent.WorkflowInstanceId,
                StepInstanceId = workflowStepRequestedEvent.StepInstanceId,
                StepName = workflowStepRequestedEvent.StepName,
                CorrelationId = workflowStepRequestedEvent.CorrelationId,
                Success = isSuccessful,
                ResultPayloadJson = JsonSerializer.Serialize(entity)
            };
        }
    }
}
