using MediatR;

namespace Core.CQRS.EventManager;
public interface IIntegrationEventHandler<TEvent> : INotificationHandler<TEvent>
                                                        where TEvent : IIntegrationEvent
{
}