using KollexionSuite.Services.Workflows.Domain.Common;
using KollexionSuite.Services.Workflows.Domain.Utilities;

namespace KollexionSuite.Services.Workflows.Domain.Entities
{
    public class WorkflowStepInstance : BaseEntity
    {
        public Guid WorkflowInstanceId { get; private set; }
        public WorkflowInstance WorkflowInstance { get; private set; } = default!;

        public Guid WorkflowStepDefinitionId { get; private set; }
        public WorkflowStepDefinition WorkflowStepDefinition { get; private set; } = default!;

        public int Order { get; private set; }
        public WorkflowStepStatus Status { get; private set; } = WorkflowStepStatus.NotStarted;

        public string? RequestPayloadJson { get; private set; }
        public string? ResultPayloadJson { get; private set; }
        public string? ErrorMessage { get; private set; }

        private WorkflowStepInstance() { }

        public WorkflowStepInstance(Guid stepDefinitionId, int order, Guid workflowInstanceId)
        {
            WorkflowStepDefinitionId = stepDefinitionId;
            Order = order;
            WorkflowInstanceId = workflowInstanceId;
        }

        public void MarkRequested(string? payloadJson)
        {
            Status = WorkflowStepStatus.Requested;
            RequestPayloadJson = payloadJson;
            MarkUpdated();
        }

        public void MarkSucceeded(string? resultPayloadJson)
        {
            Status = WorkflowStepStatus.Succeeded;
            ResultPayloadJson = resultPayloadJson;
            MarkUpdated();
        }

        public void MarkFailed(string errorMessage)
        {
            Status = WorkflowStepStatus.Failed;
            ErrorMessage = errorMessage;
            MarkUpdated();
        }

        public void MarkRolledBack(string? resultPayloadJson = null)
        {
            Status = WorkflowStepStatus.RolledBack;
            ResultPayloadJson = resultPayloadJson;
            MarkUpdated();
        }
    }
}
