namespace Ordering.Domain.Abstractions;

public interface IAggregate<T> : IAggregate, IEntity<T>
{
}

public interface IAggregate : IEntity
{
    IReadOnlyList<IDomainEvent> DomainEvents { get; }
    
    //Approach 1: Separate Methods for Getting and Clearing Domain Events
    void ClearDomainEvents();
    
    //Approach 2: Combined Method for Clearing and Returning Domain Events
    IDomainEvent[] ClearDomainEvent();
}