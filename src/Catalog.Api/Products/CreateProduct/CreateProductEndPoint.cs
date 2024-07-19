namespace Catalog.Api.Products.CreateProduct;

public sealed record CreateProductRequest(
    string Name,
    string Description,
    string ImageFile,
    List<string> Category,
    decimal Price
);

// public record CreateProductResponse(Result<Product> result);

public class CreateProductEndPoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/Products",
                async (CreateProductRequest request, ISender sender) =>
                {
                    var command = request.Adapt<CreateProductCommand>();
                    var response = await sender.Send(command);
                    // var response = result.Adapt<CreateProductResponse>();
                    return Results.Created($"/Products/{response}", response);
                })
            .WithName("Products")
            .Produces<Result>(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Create Product")
            .WithDescription("Create Product");
    }
}