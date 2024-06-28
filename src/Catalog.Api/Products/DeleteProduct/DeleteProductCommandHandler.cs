using BuildingBlocks.ApiResultWrapper;
using Catalog.Api.Exceptions;
using Catalog.Api.Models.Products;
using Catalog.Api.Products.CreateProduct;

namespace Catalog.Api.Products.DeleteProduct;

public sealed record DeleteProductCommand(Guid Id)
    : ICommand<Result>;

public record DeleteProductResult(Result result);

public class DeleteProductCommandHandler(IDocumentSession session, ILogger<DeleteProductCommandHandler> logger)
    : ICommandHandler<DeleteProductCommand, Result>
{
    public async Task<Result> Handle(DeleteProductCommand command, CancellationToken cancellationToken)
    {
        logger.LogInformation("DeleteProductCommandHandler.Handle was called {command}", command);

        var product = await session.LoadAsync<Product>(command.Id, cancellationToken);
        if (product is null)
        {
            return Result.Failure(ProductErrors.ProductNotFoundError);
        }
        session.Delete<Product>(command.Id);
        await session.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}