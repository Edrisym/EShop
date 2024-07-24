using Ordering.Domain.Models;

namespace Ordering.Domain.Event;

public record OrderCreatedEvent(Order Order) : IDomainEvent;
