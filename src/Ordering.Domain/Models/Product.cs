namespace Ordering.Domain.Models;

public class Product : Entity<ProductId>
{
    public string? Name { get; set; } = default!;
    public decimal Price { get; set; } = default!;
}