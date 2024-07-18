namespace Ordering.Domain.Abstractions;

public abstract class Aggregate<TId> : Entity<TId>, IAggregate<TId>
{
    private readonly List<IDomainEvent> _domainEvents = [];

    public IReadOnlyList<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

    protected void RaiseDomainEvent(IDomainEvent @event) => _domainEvents.Add(@event);
    
    
    //Approach 1: Separate Methods for Getting and Clearing Domain Events
    public IReadOnlyCollection<IDomainEvent> GetDomainEvents() => _domainEvents.ToList();
    public void ClearDomainEvents() => _domainEvents.Clear();

    
    //Approach 2: Combined Method for Clearing and Returning Domain Events
    public IDomainEvent[] ClearDomainEvent()
    {
        IDomainEvent[] @events = _domainEvents.ToArray();
        _domainEvents.Clear();
        return @events;
    }
}