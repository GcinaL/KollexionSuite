using DebtCollection.Services.Debtors.Infrastructure.Data;
using KollexionSuite.Services.Debtors.Domain.IRepositories;
using KollexionSuite.Services.Debtors.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace KollexionSuite.Services.Debtors.Infrastructure.Extentions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<DebtorDbContext>(opts =>
                opts.UseSqlServer(config.GetConnectionString("DefaultConnection"),
                    sql => sql.EnableRetryOnFailure()));

            // repositories
            services.AddScoped<IDebtorRepository, DebtorRepository>();
            services.AddScoped<IContactRepository, ContactRepository>();

            using (var scope = services.BuildServiceProvider().CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<DebtorDbContext>();
                db.Database.EnsureCreated();
            }

            return services;
        }
    }
}
