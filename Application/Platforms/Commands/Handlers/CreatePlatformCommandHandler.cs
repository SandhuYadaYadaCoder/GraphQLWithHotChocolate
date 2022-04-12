using ApplicationShared.Platform.Commands;
using ApplicationShared.Platform.ReadDtos;
using Common.Extensions;
using Core.CQRS.CommandManager;
using Core.UnitOfWorkManager;
using DataAccess.Entities;

namespace Application.Platforms.Commands.Handlers;

public class CreatePlatformCommandHandler : ICommandHandlerWithReturn<CreatePlatformCommand, PlatformReadDto>
{
    private readonly IPersistenceUnitOfWork _persistenceUnitOfWork;
    private readonly IUnitOfWork _unitOfWork;

    public CreatePlatformCommandHandler(IPersistenceUnitOfWork persistenceUnitOfWork, IUnitOfWork unitOfWork)
    {
        _persistenceUnitOfWork = persistenceUnitOfWork;
        _unitOfWork = unitOfWork;
    }

    public async Task<PlatformReadDto> Handle(CreatePlatformCommand request, CancellationToken cancellationToken)
    {
        Platform platform = new() { Name = request.Name, LicenseKey = GuidExtension.FromString(request.Name) };

        _unitOfWork
            .GetRepository<Platform>()
            .Add(platform);

        await _persistenceUnitOfWork.SaveChangesAsync();

        return new PlatformReadDto(platform.Id, platform.Name, platform.LicenseKey, null);
    }
}
