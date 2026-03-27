using KollexionSuite.Services.MessageBroker.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KollexionSuite.Services.MessageBroker.Infrastructure.Configurations
{
    public class OutboxEventConfiguration : IEntityTypeConfiguration<OutboxEvent>
    {
        public void Configure(EntityTypeBuilder<OutboxEvent> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.KafkaTopic)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.Key)
                .HasMaxLength(200);

            builder.Property(x => x.PayloadJson)
                .IsRequired();

            builder.Property(x => x.Status)
                .HasConversion<int>()
                .IsRequired();

            builder.Property(x => x.RetryCount).IsRequired();

            builder.Property(x => x.Status)
             .HasConversion<string>()
             .HasMaxLength(50);
        }
    }
}
