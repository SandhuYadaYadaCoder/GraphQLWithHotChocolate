using Api.GraphQL.Platform;
using Api.GraphQL.PlatformCommand;
using Core.CQRS.CommandManager;
using Core.CQRS.QueryManager;

namespace Api.GraphQL;

public static class GraphQLConfigurations
{
    public static IServiceCollection RegisterGraphQL(this IServiceCollection services)
    {
        services
            .AddGraphQLServer()
            .AddQueryType<Query>()
            .AddMutationType<Mutation>()
            .AddType<PlatformType>()
            .AddType<PlatformCliType>()
            .RegisterService<IQueryManager>(ServiceKind.Resolver)
            .RegisterService<ICommandManager>(ServiceKind.Resolver)
            .AddFiltering()
            .AddSorting()
            .AddInMemorySubscriptions();

        return services;
    }
}
