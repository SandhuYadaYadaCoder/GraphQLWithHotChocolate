using ApplicationShared.Platform.ReadDtos;
using ApplicationShared.PlatformCommand.Queries;
using ApplicationShared.PlatformCommand.ReadDtos;
using Core.CQRS.QueryManager;
using Core.UnitOfWorkManager;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.PlatformCommands.Queries.Handlers;

public class GetPlatformClisQueryHandler : IQueryHandler<GetPlatformClisQuery, IEnumerable<PlatformCliReadDto>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetPlatformClisQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public Task<IEnumerable<PlatformCliReadDto>> Handle(GetPlatformClisQuery request, CancellationToken cancellationToken)
    {
        return Task.FromResult(_unitOfWork
            .GetRepository<PlatformCli>()
            .GetAll()
            .Include(x => x.Platform)
            .Select(x => new PlatformCliReadDto(
                x.Id,
                x.HowTo!,
                x.CommandLine!,
                x.PlatformId,
                new PlatformReadDto(x.Platform.Id, x.Platform.Name!, null)
                ))
            .AsEnumerable());
    }
}
