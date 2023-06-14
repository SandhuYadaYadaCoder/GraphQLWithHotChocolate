using Application.Platforms.QueryHandlers;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application;

public static class ApplicationModuleConfiguration
{
    public static IServiceCollection RegisterApplication(this IServiceCollection services)
    {
        services.AddMediatR(conf => conf.AsScoped() , typeof(GetPlatformQueryHandler).GetTypeInfo().Assembly);

        return services;
    }
}
