using KollexionSuite.Services.Shared.Common.Abstraction;
using Microsoft.Extensions.Logging;

namespace KollexionSuite.Services.Shared.Common.Implementations
{
    public class BackgroundTaskRunner : IBackgroundTaskRunner
    {
        private readonly ILogger<BackgroundTaskRunner> _logger;

        public BackgroundTaskRunner(ILogger<BackgroundTaskRunner> logger)
        {
            _logger = logger;
        }

        public void Run(Task[] tasks, string objectId, string description)
        {
            _ = Task.WhenAll(tasks)
                .ContinueWith(t =>
                {
                    if (t.Exception != null)
                    {
                        _logger.LogError(
                            t.Exception,
                            "Background tasks failed for {Description} (Id: {Id})",
                            description,
                            objectId
                        );
                    }
                }, TaskScheduler.Default);
        }
    }
}
