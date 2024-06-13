namespace Catalog.Api.Models;

public class Products
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string ImageFile { get; set; }
    public decimal Price { get; set; }
    public List<string> Category { get; set; }
}