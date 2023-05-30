using MediatR;

namespace Core.CQRS.EventManager;
public interface IDomainEventHandler<in TEvent> : INotificationHandler<TEvent>
                                                      where TEvent : IDomainEvent
{
}