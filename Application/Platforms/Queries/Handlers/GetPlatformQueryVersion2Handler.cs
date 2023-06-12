using ApplicationShared.Platform.Queries;
using ApplicationShared.Platform.ReadDtos;
using ApplicationShared.PlatformCommand.ReadDtos;
using Core.CQRS.QueryManager;
using Core.UnitOfWorkManager;
using DataAccess.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Application.Platforms.QueryHandlers;

public class GetPlatformQueryVersion2Handler : IQueryHandler<GetPlatformsVersion2Query, IQueryable<PlatformReadDto>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetPlatformQueryVersion2Handler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }


    public Task<IQueryable<PlatformReadDto>> Handle(GetPlatformsVersion2Query request, CancellationToken cancellationToken)
    {
        return Task.FromResult(request
            .AppDbContext
            .Platforms
            .Include(x => x.PlatformClis)
            .Select(x => new PlatformReadDto(
                x.Id,
                x.Name!,
                x.LicenseKey!,
                x.PlatformClis
                    .Select(y => new PlatformCliReadDto(
                        y.Id, 
                        y.HowTo!, 
                        y.CommandLine!, 
                        y.PlatformId, 
                        null)
                    ))
            )
        );

            //Task.FromResult(_unitOfWork
            //.GetRepository<Platform>()
            //.GetAll()
            //.Include(x => x.PlatformClis)
            //.Select(x => new PlatformReadDto(
            //    x.Id,
            //    x.Name!,
            //    x.LicenseKey!,
            //    x.PlatformClis
            //    .Select(y => new PlatformCliReadDto(y.Id, y.HowTo!, y.CommandLine!, y.PlatformId, null)))));
    }
}
