using ApplicationShared.Platform.ReadDtos;
using ApplicationShared.PlatformCommand.Queries;
using ApplicationShared.PlatformCommand.ReadDtos;
using Core.CQRS.QueryManager;
using Core.UnitOfWorkManager;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.PlatformCommands.Queries.Handlers;

public class GetCommandsQueryHandler : IQueryHandler<GetPlatformCommandsQuery, IEnumerable<CommandReadDto>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetCommandsQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public Task<IEnumerable<CommandReadDto>> Handle(GetPlatformCommandsQuery request, CancellationToken cancellationToken)
    {
        return Task.FromResult(_unitOfWork
            .GetRepository<PlatformCommand>()
            .GetAll()
            .Include(x => x.Platform)
            .Select(x => new CommandReadDto(
                x.Id,
                x.HowTo!,
                x.CommandLine!,
                x.PlatformId,
                new PlatformReadDto(x.Platform.Id, x.Platform.Name!, null)
                ))
            .AsEnumerable());
    }
}
