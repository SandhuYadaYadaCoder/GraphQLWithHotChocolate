using Core.CQRS.EventManager;

namespace ApplicationShared.Platform.Events;
public class PlatformCreatedDomainEvent : IDomainEvent
{
    public int PlatformId { get; set;}

    public PlatformCreatedDomainEvent(int platformId)
    {
        PlatformId = platformId;
    }
}
