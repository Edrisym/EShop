namespace Basket.Api.Basket.DeleteBasket;

public sealed record DeleteBasketCommand(string UserName) : ICommand<Result>;

public sealed record DeleteBasketResult(Result Result);
public class DeleteBasketHandler : ICommandHandler<DeleteBasketCommand, Result>
{
    public async Task<Result> Handle(DeleteBasketCommand request, CancellationToken cancellationToken)
    {
        // TODO: delete basket from database and cache //session.Delete<Product>(command. Id);

        return Result.Success();
    }
}