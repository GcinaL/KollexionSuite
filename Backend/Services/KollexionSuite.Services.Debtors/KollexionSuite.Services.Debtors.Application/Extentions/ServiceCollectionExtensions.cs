
using KollexionSuite.Services.Debtors.Application.Interfaces;
using KollexionSuite.Services.Debtors.Application.Services;
using KollexionSuite.Services.Shared.Audit;
using KollexionSuite.Services.Shared.Common.Extensions;
using KollexionSuite.Services.Shared.MessageBroker;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace KollexionSuite.Services.Debtors.Application.Extentions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddBackgroundTaskRunner();
            services.AddMessageBrokerClient(configuration);
            services.AddAuditClient(configuration);

            services.AddScoped<IDebtorService, DebtorService>();

            return services;
        }
    }
}
