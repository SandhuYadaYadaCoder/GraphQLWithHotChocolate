using ApplicationShared.Platform.Commands;
using ApplicationShared.Platform.Events;
using ApplicationShared.Platform.ReadDtos;
using Common.Extensions;
using Core.CQRS.CommandManager;
using Core.CQRS.EventManager;
using Core.UnitOfWorkManager;
using DataAccess.Entities;

namespace Application.Platforms.Commands.Handlers;

public class CreatePlatformCommandHandler : ICommandHandlerWithReturn<CreatePlatformCommand, PlatformReadDto>
{
    private readonly IPersistenceUnitOfWork _persistenceUnitOfWork;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IEventManager _eventManager;

    public CreatePlatformCommandHandler(
        IPersistenceUnitOfWork persistenceUnitOfWork, 
        IUnitOfWork unitOfWork,
        IEventManager eventManager)
    {
        _persistenceUnitOfWork = persistenceUnitOfWork;
        _unitOfWork = unitOfWork;
        _eventManager = eventManager;
    }

    public async Task<PlatformReadDto> Handle(CreatePlatformCommand request, CancellationToken cancellationToken)
    {
        Platform platform = new()
        {
            Name = request.Name,
            LicenseKey = GuidExtension.FromString(request.Name)
        };

        _unitOfWork
            .GetRepository<Platform>()
            .Add(platform);

        await _persistenceUnitOfWork.SaveChangesAsync();

        await _eventManager.Publish(new PlatformCreatedDomainEvent(platform.Id));

        return new PlatformReadDto(platform.Id, platform.Name, platform.LicenseKey, null);
    }
}
