using Domain.DomainEvents;

namespace Domain.Entities;

public abstract class AggregateRoot : Entity
{
    private readonly List<IDomainEvent> _domainEvents = new();
    
    protected AggregateRoot(Guid id) : base(id) { }

    public void RaiseEvent(IDomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }

    public List<IDomainEvent> PullDomainEvents()
    {
        var events = new List<IDomainEvent>(_domainEvents);
        
        _domainEvents.Clear();

        return events;
    }
}