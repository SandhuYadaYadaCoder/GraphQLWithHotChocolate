using ApplicationShared.Platform.ReadDtos;
using Core.CQRS.QueryManager;
using Core.UnitOfWorkManager;
using DataAccess;
using PlatformEntity = DataAccess.Entities.Platform;

namespace ApplicationShared.Platform.Queries;

public class GetPlatformsVersion2Query : IQuery<IQueryable<PlatformEntity>>
{
    public GetPlatformsVersion2Query(AppDbContext appDbContext)
    {
        AppDbContext = appDbContext;
    }

    public AppDbContext AppDbContext { get; set; }
    public IUnitOfWork UnitOfWork { get ; init ; }
}

public class GetPlatformsVersion3Query : IQuery<IQueryable<PlatformReadDto>>
{
    public GetPlatformsVersion3Query(AppDbContext appDbContext)
    {
        AppDbContext = appDbContext;
    }

    public AppDbContext AppDbContext { get; set; }
    public IUnitOfWork UnitOfWork { get; init; }
}
