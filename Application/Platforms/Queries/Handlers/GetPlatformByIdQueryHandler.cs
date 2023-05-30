using ApplicationShared.Platform.Queries;
using ApplicationShared.Platform.ReadDtos;
using ApplicationShared.PlatformCommand.ReadDtos;
using Core.CQRS.QueryManager;
using Core.UnitOfWorkManager;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Platforms.Queries.Handlers;
public class GetPlatformByIdQueryHandler : IQueryHandler<GetPlatformByIdQuery, PlatformReadDto?>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetPlatformByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<PlatformReadDto?> Handle(GetPlatformByIdQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork
            .GetRepository<Platform>()
            .FindBy(x => x.Id == request.Id)!
            .Include(x => x.PlatformClis)
            .Select(x => new PlatformReadDto(
                x.Id,
                x.Name!,
                x.LicenseKey!,
                x.PlatformClis
                .Select(y => new PlatformCliReadDto(y.Id, y.HowTo!, y.CommandLine!, y.PlatformId, null))
                .AsEnumerable()))
            .FirstOrDefaultAsync(cancellationToken: cancellationToken);
    }
}
