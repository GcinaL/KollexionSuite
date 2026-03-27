using KollexionSuite.Services.MessageBroker.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KollexionSuite.Services.MessageBroker.Infrastructure.Configurations
{
    public class TopicSubscriptionConfiguration : IEntityTypeConfiguration<TopicSubscription>
    {
        public void Configure(EntityTypeBuilder<TopicSubscription> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.TopicName)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.CallbackUrl)
                .IsRequired()
                .HasMaxLength(1000);

            builder.Property(x => x.Description)
                .HasMaxLength(1000);

            builder.Property(x => x.IsActive)
                .IsRequired();
        }
    }
}
