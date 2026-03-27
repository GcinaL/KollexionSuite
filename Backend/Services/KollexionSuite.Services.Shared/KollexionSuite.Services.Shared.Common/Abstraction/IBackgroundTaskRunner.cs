namespace KollexionSuite.Services.Shared.Common.Abstraction
{
    public interface IBackgroundTaskRunner
    {
        void Run(Task[] tasks, string objectId, string description);
    }
}
