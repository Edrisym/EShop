namespace Ordering.Domain.Primitives;
public record ProductId
{
    public Guid Value { get; }
    private ProductId(Guid value) => Value = value;
    public static ProductId Of(Guid value)
    {
        ArgumentNullException.ThrowIfNull(value);
        if (value == Guid.Empty)
        {
            throw new Exception("ProductId cannot be empty.");
        }

        return new ProductId(value);
    }
}