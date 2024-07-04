namespace Basket.Api.Basket.StoreBasket;


public sealed record StoreBasketCommand(ShoppingCart Cart) 
    : ICommand<Result>;
public sealed record StoreBasketResult(Result Result);

public class StoreBasketHandler : ICommandHandler<StoreBasketCommand, Result>
{
    public async Task<Result> Handle(StoreBasketCommand command, CancellationToken cancellationToken)
    {
        //store Cart
        //If exist Update
        ShoppingCart cart = command.Cart;
        return Result.Success(cart);
    }
}