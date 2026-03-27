
namespace KollexionSuite.Services.Shared.Utilities
{
    public enum WorkflowStatus
    {
        Pending = 0,
        InProgress = 1,
        Completed = 2,
        Failed = 3,
        Compensating = 4
    }

    public enum WorkflowStepStatus
    {
        NotStarted = 0,
        Requested = 1,
        Succeeded = 2,
        Failed = 3,
        RolledBack = 4
    }
}
