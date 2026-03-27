using KollexionSuite.Services.Shared.Audit.Abstractions;
using KollexionSuite.Services.Shared.Audit.Implementations;
using KollexionSuite.Services.Shared.Audit.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace KollexionSuite.Services.Shared.Audit
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAuditClient(this IServiceCollection services, IConfiguration config)
        {
            services.Configure<AuditServiceSettings>(config.GetSection("AuditService"));

            services.AddHttpClient<IAuditClient, AuditClient>();

            return services;
        }
    }
}
