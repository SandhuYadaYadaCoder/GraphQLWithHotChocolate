using ApplicationShared.Platform.Events;
using Core.CQRS.EventManager;
using Serilog;

namespace Application.Audit.Events.Handlers;
public class AuditOnPlatformCreatedDomainEventHandler : IDomainEventHandler<PlatformCreatedDomainEvent>
{
    private readonly ILogger _logger;

    public AuditOnPlatformCreatedDomainEventHandler(ILogger logger)
    {
        _logger = logger;
    }

    public Task Handle(PlatformCreatedDomainEvent notification, CancellationToken cancellationToken)
    {
        return Task.Run(() =>
        {
            _logger.Information($"Auditing on platform with Id {notification.PlatformId}");
        });
    }
}
