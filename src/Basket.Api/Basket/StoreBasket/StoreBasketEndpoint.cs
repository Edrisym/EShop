using Mapster;

namespace Basket.Api.Basket.StoreBasket;

public sealed record StoreBasketRequest(ShoppingCart Cart);

public sealed record StoreBasketResponse(string UserName);

public class StoreBasketEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/basket",
                async (StoreBasketRequest request, ISender sender) =>
                {
                    var command = request.Adapt<StoreBasketCommand>();
                    var result = sender.Send(command);
                    var response = result.Adapt<StoreBasketResponse>();
                    return result;
                }).WithName("CreateBasket")
            .Produces<Result>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Create basket")
            .WithDescription("Create basket");
        ;
    }
}