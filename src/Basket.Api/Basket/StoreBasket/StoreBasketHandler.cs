using Basket.Api.IRrepository;
using Discount.Grpc;

namespace Basket.Api.Basket.StoreBasket;

public sealed record StoreBasketCommand(ShoppingCart Cart)
    : ICommand<Result>;

public sealed record StoreBasketResult(Result Result);

public class StoreBasketHandler(
    IBasketRepository repository,
    DiscountProtoService.DiscountProtoServiceClient discountProto)
    : ICommandHandler<StoreBasketCommand, Result>
{
    public async Task<Result> Handle(StoreBasketCommand command, CancellationToken cancellationToken)
    {
        await CalculateDiscountAsync(command.Cart, cancellationToken: cancellationToken);

        var basket = await repository
            .StoreBasket(command.Cart, cancellationToken);

        return Result.Success(basket.UserName);
    }

    private async Task CalculateDiscountAsync(ShoppingCart shoppingCart, CancellationToken cancellationToken)
    {
        foreach (var item in shoppingCart.Items)
        {
            var productName = new GetDiscountRequest
            {
                ProductName = item.ProductName
            };

            var coupon = await discountProto
                .GetDiscountAsync(productName, cancellationToken: cancellationToken);
            item.Price -= coupon.Amount;
        }
    }
}