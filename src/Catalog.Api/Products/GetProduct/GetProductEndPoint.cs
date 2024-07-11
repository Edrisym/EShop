using BuildingBlocks.ApiResultWrapper;

namespace Catalog.Api.Products.GetProduct;

public record GetProductRequest(int? PageNumber = 1, int? PageSize = 10);
public sealed record GetProductsResponse(Result Products);

public class GetProductEndPoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/Products", async 
                ([AsParameters] GetProductRequest request, ISender sender) =>
            {
                var query = request.Adapt<GetProductQuery>();
                var response = await sender.Send(query);
                // var response = result.Adapt<GetProductsResponse>();
                return Results.Ok(response);
            })
            .WithName("GetProducts")
            .Produces<Result>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Get Product")
            .WithDescription("Get Product")
            .RequireRateLimiting("fixed");
    }
}