using KollexionSuite.Services.FileManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace KollexionSuite.Services.FileManager.Infrastructure.Data
{
    public class FileDbContext : DbContext
    {
        public FileDbContext(DbContextOptions<FileDbContext> options) : base(options) { }

        public DbSet<FileRecord> Files => Set<FileRecord>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<FileRecord>()
                .HasKey(f => f.FileId);
        }
    }
}
