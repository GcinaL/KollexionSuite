using KollexionSuite.Services.MessageBroker.Application.Interfaces;
using KollexionSuite.Services.MessageBroker.Domain.Common;
using KollexionSuite.Services.MessageBroker.Domain.IRepositories;
using KollexionSuite.Services.MessageBroker.Infrastructure.Data;
using KollexionSuite.Services.MessageBroker.Infrastructure.HostedServices;
using KollexionSuite.Services.MessageBroker.Infrastructure.Messaging;
using KollexionSuite.Services.MessageBroker.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace KollexionSuite.Services.MessageBroker.Infrastructure.Extentions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MessageBrokerDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                    sql => sql.EnableRetryOnFailure()));

            // Repositories
            services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<MessageBrokerDbContext>());
            services.AddScoped(typeof(IMessageBrokerRepository<>), typeof(MessageBrokerRepository<>));
            services.AddScoped<IOutboxEventRepository, OutboxEventRepository>();

            // Kafka
            services.Configure<KafkaSettings>(configuration.GetSection("Kafka"));
            services.AddSingleton<IKafkaProducer, KafkaProducer>();

            // Hosted services
            services.AddHostedService<OutboxPublisherHostedService>();
            services.AddHostedService<ResultsConsumerHostedService>();

            using (var scope = services.BuildServiceProvider().CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<MessageBrokerDbContext>();
                db.Database.EnsureCreated();
            }

            return services;
        }
    }
}
