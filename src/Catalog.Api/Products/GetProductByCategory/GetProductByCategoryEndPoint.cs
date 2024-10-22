using Catalog.Api.Models.Products;

namespace Catalog.Api.Products.GetProductByCategory;

//GetProductByCategory
public class GetProductByCategoryEndPoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/products/category/{category}",
                async (string category, ISender sender) =>
                {
                    var result = await sender.Send(new GetProductByCategoryQuery(category));
                    var response = result.Adapt<Result<IReadOnlyCollection<Product>>>();
                    return Results.Ok(response);
                }).WithName("GetProductsByCategory")
            .Produces<Result<IReadOnlyCollection<Product>>>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Get product by category")
            .WithDescription("Get product by category");
    }
}