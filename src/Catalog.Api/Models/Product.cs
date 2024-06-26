using BuildingBlocks.ApiResultWrapper;
using BuildingBlocks.Common.Response;
using Catalog.Api.Products.CreateProduct;

namespace Catalog.Api.Models;

public class Product
{
    public Product(){}
    
    private Product(string name, string description, string imageFile, decimal price, List<string> category)
    {
        Price = price;
        Name = name;
        Description = description;
        ImageFile = imageFile;
        Category = category;
    }

    public static Result<Product> CreateProduct(
        string name,
        string description,
        string imageFile,
        decimal price,
        List<string> category)
    {
        if (category == null) throw new ArgumentNullException(nameof(category));
        if (string.IsNullOrWhiteSpace(name))
            return Result.Failure<Product>(ProductErrors.InvalidProductName);
        if (string.IsNullOrWhiteSpace(description))
            //TODO
        if (string.IsNullOrWhiteSpace(imageFile))
            //TODO
        ArgumentOutOfRangeException.ThrowIfNegative(price);

        var product = new Product(name, description, imageFile, price, category);

        return product;
    }
 
    public static Product UpdateProduct(
        
        //TODO
        Guid id,
        string name,
        string description,
        string imageFile,
        decimal price,
        List<string> category)
    {
        var product = new Product
        {
            Id = id,
            Name = name,
            Description = description,
            ImageFile = imageFile,
            Price = price,
            Category = category
        };

        return product;
    }


    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string ImageFile { get; set; }
    public decimal Price { get; set; }
    public List<string> Category { get; set; }
}