using Basket.Api.IRrepository;
using BuildingBlocks.Common.Response;
using Mapster;

namespace Basket.Api.Basket.GetBasket
{
    public sealed record GetBasketQuery(string UserName) 
        : IQuery<Result>;

    public sealed record GetBasketResult(Result Result);

    public class GetBasketHandler(IBasketRepository repository) : IQueryHandler<GetBasketQuery,Result>
    {
        public async Task<Result> Handle(GetBasketQuery query, CancellationToken cancellationToken)
        {
            var basket = await repository.GetBasket(query.UserName);
            return Result.Success(basket);
        }
    }
}