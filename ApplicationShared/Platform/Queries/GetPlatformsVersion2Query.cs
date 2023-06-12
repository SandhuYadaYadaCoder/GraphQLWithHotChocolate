using ApplicationShared.Platform.ReadDtos;
using Core.CQRS.QueryManager;
using Core.UnitOfWorkManager;
using DataAccess;

namespace ApplicationShared.Platform.Queries;

public class GetPlatformsVersion2Query : IQuery<IQueryable<PlatformReadDto>>
{
    public GetPlatformsVersion2Query(AppDbContext appDbContext)
    {
        AppDbContext = appDbContext;
    }

    public AppDbContext AppDbContext { get; set; }
}
