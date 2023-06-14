using ApplicationShared.PlatformCommand.ReadDtos;
using Core.CQRS.QueryManager;
using Core.UnitOfWorkManager;

namespace ApplicationShared.PlatformCommand.Queries;

public class GetPlatformClisQuery : IQuery<IEnumerable<PlatformCliReadDto>>
{
    public IUnitOfWork UnitOfWork { get; init; }
    public GetPlatformClisQuery(IUnitOfWork unitOfWork)
    {
        UnitOfWork = unitOfWork;
    }
}
