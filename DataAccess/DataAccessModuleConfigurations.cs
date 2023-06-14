using DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccess;

public static class DataAccessModuleConfigurations
{
    public static IServiceCollection RegisterDataAccess(this IServiceCollection services, string connectionString)
    {
        //services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

        services.AddPooledDbContextFactory<AppDbContext>(options => options.UseSqlServer(connectionString));

        services.AddScoped<IRepositoryFactory, RepositoryFactory>();

        return services;
    }
}
