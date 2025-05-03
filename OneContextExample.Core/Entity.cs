using Mediator;

namespace OneContextExample.Core;

public abstract class Entity : IEntity, IDomainEventsProvider
{
    private List<INotification> _domainEvents = new();

    protected void AddEvent(INotification domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }

    IReadOnlyList<INotification> IDomainEventsProvider.ExtractAll()
    {
        var events = _domainEvents;
        _domainEvents = [];
        return events.AsReadOnly();
    }

    public abstract Guid Id { get; }
}