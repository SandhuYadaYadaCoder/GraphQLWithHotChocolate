using ApplicationShared.Platform.ReadDtos;
using Core.CQRS.QueryManager;
using Core.UnitOfWorkManager;
using PlatformEntity = DataAccess.Entities.Platform;

namespace ApplicationShared.Platform.Queries;

public class GetPlatformsQuery : IQuery<IQueryable<PlatformEntity>>
{
    public GetPlatformsQuery(IUnitOfWork unitOfWork)
    {
        UnitOfWork = unitOfWork;
    }

    public IUnitOfWork UnitOfWork { get; init; }
}
