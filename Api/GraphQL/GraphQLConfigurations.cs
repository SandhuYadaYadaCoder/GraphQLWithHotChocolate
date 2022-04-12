using Api.GraphQL.Platform;
using Api.GraphQL.PlatformCommand;
using Core.CQRS.CommandManager;
using Core.CQRS.QueryManager;
using Core.UnitOfWorkManager;
using DataAccess.Repositories;

namespace Api.GraphQL;

public static class GraphQLConfigurations
{
    public static IServiceCollection RegisterGraphQL(this IServiceCollection services)
    {
        services
            .AddGraphQLServer()
            .AddQueryType<Query>()
            //.AddMutationType<Mutation>()
            //.AddSubscriptionType<Subscription>()
            .AddType<PlatformType>()
            .AddType<CommandType>()
            .RegisterService<IQueryManager>(ServiceKind.Resolver)
            .RegisterService<ICommandManager>(ServiceKind.Resolver)
            .RegisterService<IUnitOfWork>(ServiceKind.Resolver)
            .RegisterService<IPersistenceUnitOfWork>(ServiceKind.Resolver)
            .RegisterService<IRepositoryFactory>(ServiceKind.Resolver)
            .AddFiltering()
            .AddSorting()
            .AddInMemorySubscriptions();

        return services;
    }
}
