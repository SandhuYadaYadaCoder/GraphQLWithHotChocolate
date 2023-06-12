using ApplicationShared.Platform.Queries;
using ApplicationShared.Platform.ReadDtos;
using ApplicationShared.PlatformCommand.Queries;
using ApplicationShared.PlatformCommand.ReadDtos;
using Core.CQRS.QueryManager;
using DataAccess;

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

    [UseDbContext(typeof(AppDbContext))]
    [UseFiltering]
    [UseSorting]
    public async Task<IQueryable<PlatformReadDto>> GetPlatformsVersion2([ScopedService] IQueryManager queryManager, [ScopedService] AppDbContext appDbContext)
    {
        return await queryManager.Send(new GetPlatformsVersion2Query(appDbContext));
    }

    [UseFiltering]
    [UseSorting]
    public async Task<PlatformReadDto?> GetPlatformById(int id, [ScopedService] IQueryManager queryManager)
    {
        PlatformReadDto platform = await queryManager.Send(new GetPlatformByIdQuery(id: id));
        return platform;
    }


    [UseFiltering]
    [UseSorting]
    public async Task<List<PlatformCliReadDto>> GetCommands([ScopedService] IQueryManager queryManager)
    {
        IEnumerable<PlatformCliReadDto> platformCommands = await queryManager.Send(new GetPlatformClisQuery());
        return platformCommands.ToList();
    }
}
