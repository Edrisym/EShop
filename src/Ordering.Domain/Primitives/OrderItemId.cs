namespace Ordering.Domain.Primitives;
public record OrderItemId
{
    public Guid Value { get; }
    private OrderItemId(Guid value) => Value = value;
    public static OrderItemId Of(Guid value)
    {
        ArgumentNullException.ThrowIfNull(value);
        if (value == Guid.Empty)
        {
            //TODO
            throw new Exception("OrderItemId cannot be empty.");
        }

        return new OrderItemId(value);
    }
}