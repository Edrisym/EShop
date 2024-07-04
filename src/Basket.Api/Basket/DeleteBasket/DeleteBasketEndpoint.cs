using Mapster;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace Basket.Api.Basket.DeleteBasket;

public sealed record DeleteBasketRequest(string UserName);

public sealed record DeleteBasketResponse(Result Result);

public class DeleteBasketEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("/api/basket",
                async (DeleteBasketRequest request, ISender sender) =>
                {
                    var command = request.Adapt<DeleteBasketCommand>();
                    var result = sender.Send(command);
                    var response = result.Adapt<DeleteBasketResponse>();
                    return response;
                }).WithName("DeleteBasket")
            .Produces<Result>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Delete basket")
            .WithDescription("Delete basket");
    }
}