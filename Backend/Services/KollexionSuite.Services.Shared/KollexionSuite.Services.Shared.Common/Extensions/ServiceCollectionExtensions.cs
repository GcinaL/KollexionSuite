using KollexionSuite.Services.Shared.Common.Abstraction;
using KollexionSuite.Services.Shared.Common.Implementations;
using Microsoft.Extensions.DependencyInjection;

namespace KollexionSuite.Services.Shared.Common.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddBackgroundTaskRunner(this IServiceCollection services)
        {
            services.AddSingleton<IBackgroundTaskRunner, BackgroundTaskRunner>();
            return services;
        }
    }
}
