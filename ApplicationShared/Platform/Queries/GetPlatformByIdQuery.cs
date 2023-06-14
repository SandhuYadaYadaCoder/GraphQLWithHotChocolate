using ApplicationShared.Platform.ReadDtos;
using Core.CQRS.QueryManager;
using Core.UnitOfWorkManager;

namespace ApplicationShared.Platform.Queries;
public class GetPlatformByIdQuery : IQuery<PlatformReadDto>
{
    public GetPlatformByIdQuery(IUnitOfWork unitOfWork, int id)
    {
        UnitOfWork = unitOfWork;
        Id = id;
    }

    public int Id { get; set; }
    public IUnitOfWork UnitOfWork { get ; init ; }
}
