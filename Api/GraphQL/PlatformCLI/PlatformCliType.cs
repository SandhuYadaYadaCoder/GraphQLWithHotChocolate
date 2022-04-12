using ApplicationShared.Platform.ReadDtos;
using ApplicationShared.PlatformCommand.ReadDtos;
using Core.CQRS.QueryManager;

namespace Api.GraphQL.PlatformCommand;

public class PlatformCliType : ObjectType<PlatformCliReadDto>
{
    protected override void Configure(IObjectTypeDescriptor<PlatformCliReadDto> descriptor)
    {
        descriptor.Description("Represents any executable command");

        descriptor
            .Field(x => x.Platform)
            .ResolveWith<CommandResolver>(x => x.GetPlatform(default!, default!))
            .Description("This is the platform to which the command belongs to");
    }

    private class CommandResolver
    {
        public PlatformReadDto GetPlatform(PlatformCliReadDto command, [ScopedService] IQueryManager queryManager)
        {
            // In general we send a query from this method and get results from that but I am just returning new PlatformReadDto from here.

            return new PlatformReadDto(1, "Test", new List<PlatformCliReadDto> { command });
        }
    }
}
