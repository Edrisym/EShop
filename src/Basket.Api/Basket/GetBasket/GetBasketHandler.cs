using BuildingBlocks.Common.Response;
using Mapster;

namespace Basket.Api.Basket.GetBasket
{
    public sealed record GetBasketQuery(string UserName) 
        : IQuery<Result>;

    public sealed record GetBasketResult(Result Result);

    public class GetBasketHandler : IQueryHandler<GetBasketQuery,Result>
    {
        public async Task<Result> Handle(GetBasketQuery query, CancellationToken cancellationToken)
        {
            var basket = new ShoppingCart("s");
            return Result.Success(basket);
        }
    }
}