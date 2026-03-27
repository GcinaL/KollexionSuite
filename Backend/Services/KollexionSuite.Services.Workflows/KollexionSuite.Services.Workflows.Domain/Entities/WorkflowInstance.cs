using KollexionSuite.Services.Workflows.Domain.Utilities;
using KollexionSuite.Services.Workflows.Domain.Common;

namespace KollexionSuite.Services.Workflows.Domain.Entities
{
    public class WorkflowInstance : BaseEntity
    {
        public Guid WorkflowDefinitionId { get; private set; }
        public WorkflowDefinition WorkflowDefinition { get; private set; } = default!;

        public WorkflowStatus Status { get; private set; } = WorkflowStatus.Pending;

        public string CorrelationId { get; private set; } = default!; // e.g. CaseId, DebtorId

        private readonly List<WorkflowStepInstance> _steps = new();
        public IReadOnlyCollection<WorkflowStepInstance> Steps => _steps.AsReadOnly();

        private WorkflowInstance() { }

        public WorkflowInstance(Guid workflowDefinitionId, string correlationId)
        {
            WorkflowDefinitionId = workflowDefinitionId;
            CorrelationId = correlationId;
        }

        public WorkflowStepInstance AddStepInstance(Guid stepDefinitionId, int order)
        {
            var step = new WorkflowStepInstance(stepDefinitionId, order, Id);
            _steps.Add(step);
            MarkUpdated();
            return step;
        }

        public void MarkInProgress()
        {
            Status = WorkflowStatus.InProgress;
            MarkUpdated();
        }

        public void MarkCompleted()
        {
            Status = WorkflowStatus.Completed;
            MarkUpdated();
        }

        public void MarkFailed()
        {
            Status = WorkflowStatus.Failed;
            MarkUpdated();
        }

        public void MarkCompensating()
        {
            Status = WorkflowStatus.Compensating;
            MarkUpdated();
        }
    }
}
