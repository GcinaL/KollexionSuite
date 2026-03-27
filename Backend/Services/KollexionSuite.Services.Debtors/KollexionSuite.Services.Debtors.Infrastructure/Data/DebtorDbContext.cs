using KollexionSuite.Services.Debtors.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DebtCollection.Services.Debtors.Infrastructure.Data
{
    public class DebtorDbContext : DbContext
    {
        public DebtorDbContext(DbContextOptions<DebtorDbContext> options) : base(options) { }

        public DbSet<Debtor> Debtors { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Consent> Consents { get; set; }
        public DbSet<Identifier> Identifiers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Debtor>(b =>
            {
                b.HasKey(p => p.DebtorId);
                b.Property(p => p.FirstName).HasMaxLength(400);
                b.Property(p => p.Surname).HasMaxLength(200);
                b.Property(p => p.NationalId).HasMaxLength(100);
                b.Property(p => p.KycStatus).HasMaxLength(50);
                b.HasMany(p => p.Contacts).WithOne().HasForeignKey(c => c.DebtorId).OnDelete(DeleteBehavior.Cascade);
                b.HasMany(p => p.Consents).WithOne().HasForeignKey(c => c.DebtorId).OnDelete(DeleteBehavior.Cascade);
                b.HasOne(p => p.Identifier).WithOne().HasForeignKey<Identifier>(i => i.DebtorId).OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Contact>(b =>
            {
                b.HasKey(c => c.ContactId);
                b.Property(c => c.Type).HasMaxLength(50);
                b.Property(c => c.Value).HasMaxLength(500);
            });

            modelBuilder.Entity<Consent>(b =>
            {
                b.HasKey(c => c.ConsentId);
                b.Property(c => c.Channel).HasMaxLength(50);
                b.Property(c => c.Purpose).HasMaxLength(200);
            });

            modelBuilder.Entity<Identifier>(b =>
            {
                b.HasKey(i => i.IdentifierId);
                b.Property(i => i.IdentifierType).HasMaxLength(100);
                b.Property(i => i.IdentifierValue).HasMaxLength(500);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
