namespace Core.CQRS.EventManager;
public interface IEventManager
{
    Task Publish<T>(T notification, CancellationToken cancellationToken = default) where T : IEvent;
    Task Publish<T>(IEnumerable<T> notifications) where T : IEvent;
}