using Core.CQRS.CommandManager;
using Core.CQRS.QueryManager;
using Core.UnitOfWorkManager;
using Microsoft.Extensions.DependencyInjection;

namespace Core;

public static class CoreModuleConfigurations
{
    public static IServiceCollection RegisterCore(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IQueryManager, QueryManager>();
        services.AddScoped<ICommandManager, CommandManager>();
        services.AddScoped<IPersistenceUnitOfWork, UnitOfWork>();

        return services;
    }
}
