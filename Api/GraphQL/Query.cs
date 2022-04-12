using ApplicationShared.Platform.Queries;
using ApplicationShared.Platform.ReadDtos;
using ApplicationShared.PlatformCommand.Queries;
using ApplicationShared.PlatformCommand.ReadDtos;
using Core.CQRS.QueryManager;

namespace Api.GraphQL;

public class Query
{
    [UseFiltering]
    [UseSorting]
    public async Task<List<PlatformReadDto>> GetPlatforms([ScopedService] IQueryManager queryManager)
    {
        IEnumerable<PlatformReadDto> platforms = await queryManager.Send(new GetPlatformsQuery());
        return platforms.ToList();
    }

    [UseFiltering]
    [UseSorting]
    public async Task<List<CommandReadDto>> GetCommands([ScopedService] IQueryManager queryManager)
    {
        IEnumerable<CommandReadDto> platformCommands = await queryManager.Send(new GetPlatformCommandsQuery());
        return platformCommands.ToList();
    }
}
