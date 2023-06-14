using ApplicationShared.Platform.ReadDtos;
using ApplicationShared.PlatformCommand.ReadDtos;

namespace Api.GraphQL.Platform;

public class PlatformType : ObjectType<PlatformReadDto>
{
    protected override void Configure(IObjectTypeDescriptor<PlatformReadDto> descriptor)
    {
        descriptor.Description("Represents any software or service that has a command line interface.");

        descriptor
            .Field(x => x.LicenseKey)
            .Ignore();

        descriptor
            .Field(x => x.Commands)
            .ResolveWith<Resolvers>(x => x.GetCommands(default!))
            .Description("This is the list of all available commands for this platform");
    }

    private class Resolvers
    {
        public IQueryable<PlatformCliReadDto> GetCommands(PlatformReadDto platform)
        {
            return platform.Commands.AsQueryable();
        }
    }
}
