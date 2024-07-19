namespace Ordering.Domain.Primitives;

public record CustomerId
{
    public Guid Value { get; }
    private CustomerId(Guid value) => Value = value;

    public static CustomerId Of(Guid value)
    {
        ArgumentNullException.ThrowIfNull(value);
        if (value == Guid.Empty)
        {
            //TODO
             throw new Exception("CustomerId cannot be empty.");
        }

        return new CustomerId(value);
    }
}