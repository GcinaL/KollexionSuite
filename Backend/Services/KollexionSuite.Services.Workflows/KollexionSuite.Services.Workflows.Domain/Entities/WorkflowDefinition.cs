using KollexionSuite.Services.Workflows.Domain.Common;

namespace KollexionSuite.Services.Workflows.Domain.Entities
{
    public class WorkflowDefinition : BaseEntity
    {
        public string Name { get; private set; } = default!;
        public string Description { get; private set; } = default!;
        public bool IsActive { get; private set; } = true;

        private readonly List<WorkflowStepDefinition> _steps = new();
        public IReadOnlyCollection<WorkflowStepDefinition> Steps => _steps.AsReadOnly();

        private WorkflowDefinition() { }

        public WorkflowDefinition(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public void AddStep(WorkflowStepDefinition step)
        {
            _steps.Add(step);
            MarkUpdated();
        }

        public void Deactivate()
        {
            IsActive = false;
            MarkUpdated();
        }
    }
}
