using KollexionSuite.Services.Workflows.Application.Interfaces;
using KollexionSuite.Services.Workflows.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace KollexionSuite.Services.Workflows.Application.Extentions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IWorkflowOrchestratorService, WorkflowOrchestratorService>();

            return services;
        }
    }
}
