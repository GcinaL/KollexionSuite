using DebtCollection.Services.Auditing.Entities;
using Microsoft.EntityFrameworkCore;

namespace DebtCollection.Services.Auditing.Infrastructure.Data
{
    public class AuditDbContext : DbContext
    {
        public AuditDbContext(DbContextOptions<AuditDbContext> options): base(options){ }

        public DbSet<AuditEvent> AuditEvents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AuditEvent>()
                .HasKey(a => a.EventId);
        }
    }
}
