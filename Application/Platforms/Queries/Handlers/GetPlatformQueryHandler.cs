using ApplicationShared.Platform.Queries;
using ApplicationShared.Platform.ReadDtos;
using ApplicationShared.PlatformCommand.ReadDtos;
using Core.CQRS.QueryManager;
using Core.UnitOfWorkManager;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Platforms.QueryHandlers;

public class GetPlatformQueryHandler : IQueryHandler<GetPlatformsQuery, IEnumerable<PlatformReadDto>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetPlatformQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }


    public Task<IEnumerable<PlatformReadDto>> Handle(GetPlatformsQuery request, CancellationToken cancellationToken)
    {
        return Task.FromResult(_unitOfWork
            .GetRepository<Platform>()
            .GetAll()
            .Include(x => x.PlatformClis)
            .Select(x => new PlatformReadDto(
                x.Id,
                x.Name!,
                x.LicenseKey!,
                x.PlatformClis
                .Select(y => new PlatformCliReadDto(y.Id, y.HowTo!, y.CommandLine!, y.PlatformId, null))
                .AsEnumerable()))
            .AsEnumerable());
    }
}
