using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace Basket.Api.Basket.DeleteBasket;

// public sealed record DeleteBasketRequest(string UserName);

public record DeleteBasketResponse(Result Result);

public class DeleteBasketEndpoints : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("/basket/{userName}",
                async (string userName, ISender sender) =>
                {
                    // var command = request.Adapt<DeleteBasketCommand>();
                    var result = await sender.Send(new DeleteBasketCommand(userName));
                    // var response = result.Adapt<DeleteBasketResponse>();
                    return result;
                }).WithName("DeleteBasket")
            .Produces<Result>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Delete basket")
            .WithDescription("Delete basket");
    }
}