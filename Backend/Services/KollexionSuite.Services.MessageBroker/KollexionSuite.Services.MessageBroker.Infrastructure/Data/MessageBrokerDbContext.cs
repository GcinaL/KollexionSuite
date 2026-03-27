using KollexionSuite.Services.MessageBroker.Domain.Common;
using KollexionSuite.Services.MessageBroker.Domain.Entities;
using KollexionSuite.Services.MessageBroker.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace KollexionSuite.Services.MessageBroker.Infrastructure.Data
{
    public sealed class MessageBrokerDbContext : DbContext, IUnitOfWork
    {
        public MessageBrokerDbContext(DbContextOptions<MessageBrokerDbContext> options)
            : base(options) { }

        public DbSet<OutboxEvent> OutboxEvents => Set<OutboxEvent>();
        public DbSet<TopicSubscription> TopicSubscriptions => Set<TopicSubscription>();

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
            => await base.SaveChangesAsync(cancellationToken);

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MessageBrokerDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
