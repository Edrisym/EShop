using BuildingBlocks.ApiResultWrapper;
using Catalog.Api.Models.Products;

namespace Catalog.Api.Products.GetProduct;

//Public record GetProductRequest

public class GetProductEndPoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/Products", async (ISender sender) =>
            {
                var result = await sender.Send(new GetProductQuery());
                var response = result.Adapt<Result<IReadOnlyCollection<Product>>>();
                return Results.Ok(response);
            })
            .WithName("GetProducts")
            .Produces<Result<IReadOnlyCollection<Product>>>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Get Product")
            .WithDescription("Get Product");
    }
}