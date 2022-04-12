using Api.GraphQL.Platform;
using ApplicationShared.Platform.Commands;
using ApplicationShared.Platform.ReadDtos;
using Core.CQRS.CommandManager;

namespace Api.GraphQL;

public partial class Mutation
{
    public async Task<AddPlatformPayload> AddPlatformAsync(
        AddPlatformInput addPlatformInput,
        [ScopedService] ICommandManager commandManager)
    {
        CreatePlatformCommand createPlatformCommand = new(addPlatformInput.Name);

        PlatformReadDto platformReadDto = await commandManager.Send(createPlatformCommand);

        return new AddPlatformPayload(platformReadDto);
    }
}
