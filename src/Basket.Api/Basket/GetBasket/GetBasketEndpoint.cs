using Mapster;

namespace Basket.Api.Basket.GetBasket;

public sealed record GetBasketResponse(Result Result);

public class GetBasketEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/api/Basket/{userName}", 
                async (string userName , ISender sender) =>
        {
            var result = await sender.Send(new GetBasketQuery(userName));
            var response = result.Adapt<GetBasketResponse>();
            return response;
        }).WithName("GetBasket")
        .Produces<Result>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Get basket")
        .WithDescription("Get basket");
    }
}