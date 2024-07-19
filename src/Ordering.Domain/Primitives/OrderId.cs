namespace Ordering.Domain.Primitives;

public record OrderId
{
    public Guid Value { get; }
}