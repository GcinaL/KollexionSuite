using KollexionSuite.Services.Workflows.Domain.Common;

namespace KollexionSuite.Services.Workflows.Domain.Entities
{
    public class WorkflowStepDefinition : BaseEntity
    {
        public Guid WorkflowDefinitionId { get; private set; }
        public WorkflowDefinition WorkflowDefinition { get; private set; } = default!;

        public int Order { get; private set; }
        public string StepName { get; private set; } = default!;

        /// <summary>Kafka topic where the command/request will be sent.</summary>
        public string RequestTopic { get; private set; } = default!;

        /// <summary>Kafka topic that this orchestrator will listen to for results.</summary>
        public string ResultTopic { get; private set; } = default!;

        /// <summary>Optional compensation topic if rollback is needed.</summary>
        public string? CompensationTopic { get; private set; }

        public TimeSpan Timeout { get; private set; }

        private WorkflowStepDefinition() { }

        public WorkflowStepDefinition(
            Guid workflowDefinitionId,
            int order,
            string stepName,
            string requestTopic,
            string resultTopic,
            TimeSpan timeout,
            string? compensationTopic = null)
        {
            WorkflowDefinitionId = workflowDefinitionId;
            Order = order;
            StepName = stepName;
            RequestTopic = requestTopic;
            ResultTopic = resultTopic;
            Timeout = timeout;
            CompensationTopic = compensationTopic;
        }
    }
}
