using BuildingBlocks.ApiResultWrapper;
using Catalog.Api.Products.CreateProduct;

namespace Catalog.Api.Models.Products;

public class Product
{
    public Product()
    {
    }

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
        List<string> categories)
    {
        if (categories == null || categories.Count < 0)
            Result.Failure<Product>(ProductErrors.EmptyCategoryError);
        if (string.IsNullOrWhiteSpace(name))
            return Result.Failure<Product>(ProductErrors.InvalidProductName);
        if (string.IsNullOrWhiteSpace(description))
            return Result.Failure<Product>(ProductErrors.InvalidDescriptionError);
        //--
        if (string.IsNullOrWhiteSpace(imageFile))
            //TODO -- make a custom validation for the image 
        //--
            if (!price.IsGreaterThanZero())
                Result.Failure(ProductErrors.PriceIsNegativeError);

        var product = new Product(name, description, imageFile, price, categories);

        return product;
    }

    public static Result<Product> UpdateProduct(
        Guid id,
        string name,
        string description,
        string imageFile,
        decimal price,
        List<string> categories)
    {
        var product = new Product
        {
            Id = id,
            Name = name,
            Description = description,
            ImageFile = imageFile,
            Price = price,
            Category = categories
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