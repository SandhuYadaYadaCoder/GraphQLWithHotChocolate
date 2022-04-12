using ApplicationShared.Platform.ReadDtos;
using Core.CQRS.CommandManager;

namespace ApplicationShared.Platform.Commands;

public class CreatePlatformCommand : ICommandWithReturn<PlatformReadDto>
{
    public string Name { get; }

    public CreatePlatformCommand(string name)
    {
        Name = name;
    }
}
