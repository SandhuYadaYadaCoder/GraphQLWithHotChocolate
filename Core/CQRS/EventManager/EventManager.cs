using MediatR;

namespace Core.CQRS.EventManager;
public class EventManager : IEventManager
{
    private readonly IMediator _mediatR;

    public EventManager(IMediator mediatR)
    {
        _mediatR = mediatR;
    }

    public async Task Publish<T>(T request, CancellationToken cancellationToken = default) where T : IEvent
    {
        switch (request)
        {
            case IIntegrationEvent integrationEvent:
            // publish job through hangfire
            case IDomainEvent domainEvent:
                await _mediatR.Publish(request, cancellationToken);
                return;
        }
    }

    public async Task Publish<T>(IEnumerable<T> notifications) where T : IEvent
    {
        foreach (var notification in notifications)
        {
            await Publish(notification);
        }
    }
}