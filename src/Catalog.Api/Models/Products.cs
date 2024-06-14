namespace Catalog.Api.Models;

public class Products
{
    private Products(string name, string description, string imageFile, decimal price, List<string> category)
    {
        Price = price;
        Name = name;
        Description = description;
        ImageFile = imageFile;
        Category = category;
    }

    public static Products CreateProducts(
        string name,
        string description, 
        string imageFile,
        decimal price,
        List<string> category)
    {
        //TODO
        //Custom Validatiom
        
        if (category == null) throw new ArgumentNullException(nameof(category));
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Value cannot be null or whitespace.", nameof(name));
        if (string.IsNullOrWhiteSpace(description))
            throw new ArgumentException("Value cannot be null or whitespace.", nameof(description));
        if (string.IsNullOrWhiteSpace(imageFile))
            throw new ArgumentException("Value cannot be null or whitespace.", nameof(imageFile));
        ArgumentOutOfRangeException.ThrowIfNegative(price);
        
        var product = new Products(name,description,imageFile, price,category);
        
        return product;
    }


    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string ImageFile { get; set; }
    public decimal Price { get; set; }
    public List<string> Category { get; set; }
}