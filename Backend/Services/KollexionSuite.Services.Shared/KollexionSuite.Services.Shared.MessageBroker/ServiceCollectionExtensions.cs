using KollexionSuite.Services.Shared.MessageBroker.Abstractions;
using KollexionSuite.Services.Shared.MessageBroker.Implementations;
using KollexionSuite.Services.Shared.MessageBroker.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace KollexionSuite.Services.Shared.MessageBroker
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddMessageBrokerClient(this IServiceCollection services, IConfiguration config)
        {
            // Bind settings
            services.Configure<MessageBrokerSettings>(config.GetSection("MessageBroker"));

            // Register HttpClient + typed client
            services.AddHttpClient<IMessageBrokerClient, MessageBrokerClient>();

            return services;
        }
    }
}
