using ApplicationShared.Platform.Queries;
using ApplicationShared.Platform.ReadDtos;
using Core.CQRS.QueryManager;
using DataAccess.Entities;

namespace Application.Platforms.QueryHandlers;

public class GetPlatformQueryHandler : IQueryHandler<GetPlatformsQuery, IQueryable<Platform>>
{
    public async Task<IQueryable<Platform>> Handle(GetPlatformsQuery request, CancellationToken cancellationToken)
    {
        //var result = _unitOfWork.GetRepository<Platform>().GetAll();
        //return await Task.FromResult(result);

        //return await Task.FromResult(_appDbContext.Platforms.AsQueryable());

        return await Task.FromResult(request.UnitOfWork
            .GetRepository<Platform>()
            .GetAll());
    }
}
