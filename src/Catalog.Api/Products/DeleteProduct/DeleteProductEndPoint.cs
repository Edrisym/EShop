namespace Catalog.Api.Products.DeleteProduct;

// DeleteProductRequest(Guid Id);
public record DeleteProductResponse(bool isSuccess);

public class DeleteProductEndPoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("/products/{id:Guid}", async (Guid id, ISender sender) =>
            {
                var response = await sender.Send(new DeleteProductCommand(id));
                // var response = request.Adapt<DeleteProductResponse>();
                return Results.Ok(response);
            })
            .WithName("DeleteProduct")
            .Produces<DeleteProductResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .WithSummary("Delete Product")
            .WithDescription("Delete Product");
    }
}