
using KollexionSuite.Services.Auditing.Application.Interfaces;
using KollexionSuite.Services.Auditing.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace KollexionSuite.Services.Auditing.Application.Extentions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            // repositories
            services.AddScoped<IAuditService, AuditService>();

            return services;
        }
    }
}
