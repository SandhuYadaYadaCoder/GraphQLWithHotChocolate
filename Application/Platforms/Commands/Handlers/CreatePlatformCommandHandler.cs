using ApplicationShared.Platform.Commands;
using ApplicationShared.Platform.Events;
using ApplicationShared.Platform.ReadDtos;
using Common.Extensions;
using Core.CQRS.CommandManager;
using Core.CQRS.EventManager;
using Core.UnitOfWorkManager;
using DataAccess.Entities;
using Microsoft.Extensions.Logging;

namespace Application.Platforms.Commands.Handlers;

public class CreatePlatformCommandHandler : ICommandHandlerWithReturn<CreatePlatformCommand, PlatformReadDto>
{
    private readonly IPersistenceUnitOfWork _persistenceUnitOfWork;
    private readonly ILogger _logger;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IEventManager _eventManager;

    public CreatePlatformCommandHandler(
        IPersistenceUnitOfWork persistenceUnitOfWork, 
        ILogger logger,
        IUnitOfWork unitOfWork,
        IEventManager eventManager)
    {
        _persistenceUnitOfWork = persistenceUnitOfWork;
        _logger = logger;
        _unitOfWork = unitOfWork;
        _eventManager = eventManager;
    }

    public async Task<PlatformReadDto> Handle(CreatePlatformCommand request, CancellationToken cancellationToken)
    {
        _persistenceUnitOfWork.BeginTransaction();

        try
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

            _persistenceUnitOfWork.CommitTransaction();

            return new PlatformReadDto(platform.Id, platform.Name, platform.LicenseKey, null);
        }
        catch (Exception e)
        {
            _logger.LogError($"Following error occured in {nameof(CreatePlatformCommandHandler)}, Message : {e.Message}");
            _logger.LogError($"Following error occured in {nameof(CreatePlatformCommandHandler)}, Inner Exception Message : {e.InnerException?.Message}");
            _persistenceUnitOfWork.RollbackTransaction();
            throw;
        }        
    }
}
