using Basket.Api.IRrepository;

namespace Basket.Api.Basket.StoreBasket;


public sealed record StoreBasketCommand(ShoppingCart Cart) 
    : ICommand<Result>;
public sealed record StoreBasketResult(Result Result);

public class StoreBasketHandler(IBasketRepository repository) : ICommandHandler<StoreBasketCommand, Result>
{
    public async Task<Result> Handle(StoreBasketCommand command, CancellationToken cancellationToken)
    {
        var basket = await repository
            .StoreBasket(command.Cart, cancellationToken);

        //TODO if exists
        
        
        return Result.Success(basket.UserName);
    }
}