using KollexionSuite.Services.Handover.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace KollexionSuite.Services.Handover.Infrastructure.Data
{
    public class HandoverDbContext : DbContext
    {
        public HandoverDbContext(DbContextOptions<HandoverDbContext> options) : base(options) { }

        public DbSet<Template> Templates => Set<Template>();
        public DbSet<TemplateColumn> Columns => Set<TemplateColumn>();
        public DbSet<HandoverBatch> Batches => Set<HandoverBatch>();
        public DbSet<HandoverRecord> HandoverRecords => Set<HandoverRecord>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Template>(b =>
            {
                b.HasKey(x => x.TemplateId);
                b.Property(x => x.Name).HasMaxLength(256).IsRequired();
                b.HasMany(x => x.Columns)
                 .WithOne()
                 .HasForeignKey(c => c.TemplateId)
                 .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<TemplateColumn>(b =>
            {
                b.HasKey(x => x.TemplateColumnId);
                b.Property(x => x.TargetField).HasMaxLength(128).IsRequired();
            });

            modelBuilder.Entity(HandoverBatchConfig());
            modelBuilder.Entity(HandoverRecordConfig());
        }

        private static Action<Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<HandoverBatch>>HandoverBatchConfig()
        {
            return b =>
            {
                b.HasKey(x => x.BatchId);
                b.HasMany(x => x.Records)
                 .WithOne()
                 .HasForeignKey(r => r.BatchId)
                 .OnDelete(DeleteBehavior.Cascade);
            };
        }

        private static Action<Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<HandoverRecord>>HandoverRecordConfig()
        {
            return b =>
            {
                b.HasKey(x => x.HandoverRecordId);
                b.Property(x => x.RawDataJson).IsRequired();
            };
        }
    }
}
