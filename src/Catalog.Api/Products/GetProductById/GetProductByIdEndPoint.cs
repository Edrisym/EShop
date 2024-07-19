using Catalog.Api.Models.Products;

namespace Catalog.Api.Products.GetProductById;

//getProductById

public sealed record GetProductByIdResponse(Result<Product> Product);

public class GetProductByIdEndPoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/products/{id:guid}", async (Guid id, ISender sender) =>
            {
                var result = await sender.Send(new GetProductByIdQuery(id));
                var response = result.Adapt<Result<Product>>();
                return response;
            })
            .WithName("GetProductsById")
            .Produces<GetProductByIdResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Get Product by Id")
            .WithDescription("Get Product by Id");
    }
}