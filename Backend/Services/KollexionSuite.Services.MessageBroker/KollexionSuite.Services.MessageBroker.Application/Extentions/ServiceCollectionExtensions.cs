using KollexionSuite.Services.MessageBroker.Application.Interfaces;
using KollexionSuite.Services.MessageBroker.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace KollexionSuite.Services.MessageBroker.Application.Extentions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IMessageBrokerService, MessageBrokerService>();
            services.AddScoped<ITopicSubscriptionService, TopicSubscriptionService>();

            return services;
        }
    }
}
