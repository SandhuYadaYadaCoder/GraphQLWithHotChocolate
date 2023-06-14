using ApplicationShared.Platform.Queries;
using ApplicationShared.Platform.ReadDtos;
using Core.CQRS.QueryManager;
using DataAccess.Entities;

namespace Application.Platforms.QueryHandlers;

public class GetPlatformQueryVersion2Handler : IQueryHandler<GetPlatformsVersion2Query, IQueryable<Platform>>
{
    public async Task<IQueryable<Platform>> Handle(GetPlatformsVersion2Query request, CancellationToken cancellationToken)
    {
        return await Task.FromResult(request
            .AppDbContext
            .Platforms
            .AsQueryable());
    }
}


public class GetPlatformQueryVersion3Handler : IQueryHandler<GetPlatformsVersion3Query, IQueryable<PlatformReadDto>>
{
    public async Task<IQueryable<PlatformReadDto>> Handle(GetPlatformsVersion3Query request, CancellationToken cancellationToken)
    {
        return await Task.FromResult(request
            .AppDbContext
            .Platforms
            .Select(x => new PlatformReadDto(x.Id, x.Name, x.LicenseKey, null))
            .AsQueryable());
    }
}
