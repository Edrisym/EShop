namespace Basket.Api.Basket.DeleteBasket;

public sealed record DeleteBasketCommand(string UserName) : ICommand<Result>;

public sealed record DeleteBasketResult(Result Result);
public class DeleteBasketHandler : ICommandHandler<DeleteBasketCommand, Result>
{
    public async Task<Result> Handle(DeleteBasketCommand request, CancellationToken cancellationToken)
    {
        //fetch form the database
        //delete 
        //save 

        return Result.Success();
    }
}