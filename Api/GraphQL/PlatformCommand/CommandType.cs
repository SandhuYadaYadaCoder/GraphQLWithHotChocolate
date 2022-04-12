using ApplicationShared.Platform.ReadDtos;
using ApplicationShared.PlatformCommand.ReadDtos;
using Core.CQRS.QueryManager;

namespace Api.GraphQL.PlatformCommand;

public class CommandType : ObjectType<CommandReadDto>
{
    protected override void Configure(IObjectTypeDescriptor<CommandReadDto> descriptor)
    {
        descriptor.Description("Represents any executable command");

        descriptor
            .Field(x => x.Platform)
            .ResolveWith<CommandResolver>(x => x.GetPlatform(default!, default!))
            .Description("This is the platform to which the command belongs to");
    }

    private class CommandResolver
    {
        public PlatformReadDto GetPlatform(CommandReadDto command, [ScopedService] IQueryManager queryManager)
        {
            return new PlatformReadDto(1, "Test", new List<CommandReadDto> { command });
        }
    }
}
