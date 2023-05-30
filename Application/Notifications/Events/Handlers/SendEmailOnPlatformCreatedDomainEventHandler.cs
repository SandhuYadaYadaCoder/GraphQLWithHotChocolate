using ApplicationShared.Platform.Events;
using Core.CQRS.EventManager;
using Serilog;

namespace Application.Notifications.Events.Handlers;
public class SendEmailOnPlatformCreatedDomainEventHandler : IDomainEventHandler<PlatformCreatedDomainEvent>
{
    private readonly ILogger _logger;

    public SendEmailOnPlatformCreatedDomainEventHandler(ILogger logger)
    {
        _logger = logger;
    }

    public Task Handle(PlatformCreatedDomainEvent notification, CancellationToken cancellationToken)
    {
        return Task.Run(() =>
        {
            _logger.Information($"Email sent on platform created with Id: {notification.PlatformId}");
        });
    }
}
