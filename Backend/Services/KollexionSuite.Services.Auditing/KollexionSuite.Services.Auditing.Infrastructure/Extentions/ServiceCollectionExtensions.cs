using DebtCollection.Services.Auditing.Infrastructure.Data;
using DebtCollection.Services.Auditing.IRepositories;
using DebtCollection.Services.Auditing.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace KollexionSuite.Services.Auditing.Infrastructure.Extentions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<AuditDbContext>(opts =>
                opts.UseSqlServer(config.GetConnectionString("DefaultConnection"),
                    sql => sql.EnableRetryOnFailure()));

            // repositories
            services.AddScoped<IAuditRepository, AuditRepository>();

            using (var scope = services.BuildServiceProvider().CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<AuditDbContext>();
                db.Database.EnsureCreated();
            }

            return services;
        }
    }
}
