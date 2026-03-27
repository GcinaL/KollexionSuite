using KollexionSuite.Services.MessageBroker.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace KollexionSuite.Services.MessageBroker.Infrastructure.Data
{
    public static class DbSeeder
    {
        public static async Task SeedAsync(IServiceProvider services, ILogger logger, CancellationToken cancellationToken = default)
        {
            using var scope = services.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<MessageBrokerDbContext>();

            await db.Database.MigrateAsync(cancellationToken);

            if (!await db.TopicSubscriptions.AnyAsync(cancellationToken))
            {
                logger.LogInformation("Seeding default TopicSubscriptions...");

                db.TopicSubscriptions.AddRange(
                    new TopicSubscription(
                        topicName: "workflow-step-results",
                        callbackUrl: "http://workflow-orchestration/api/workflows/results",
                        description: "Default subscription for workflow orchestration step results")
                );

                await db.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
