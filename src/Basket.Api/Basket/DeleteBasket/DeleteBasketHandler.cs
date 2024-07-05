using Basket.Api.IRrepository;
using BuildingBlocks.Common.Response;

namespace Basket.Api.Basket.DeleteBasket;

public sealed record DeleteBasketCommand(string UserName) : ICommand<Result>;

public sealed record DeleteBasketResult(Result Result);

public class DeleteBasketHandler(IBasketRepository repository) : ICommandHandler<DeleteBasketCommand, Result>
{
    public async Task<Result> Handle(DeleteBasketCommand request, CancellationToken cancellationToken)
    {
        // TODO: delete basket from database and cache //session.Delete<Product>(command. Id);

        var result = await repository
            .DeleteBasket(request.UserName, cancellationToken);

        if (result == false)
        {
            return Result.Failure(Error.ValueNotFound);
        }

        return Result.Success(result);
    }
}