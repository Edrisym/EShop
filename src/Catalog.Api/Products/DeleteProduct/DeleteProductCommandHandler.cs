using Catalog.Api.Exceptions;
using Catalog.Api.Models.Products;

namespace Catalog.Api.Products.DeleteProduct;

public sealed record DeleteProductCommand(Guid Id)
    : ICommand<DeleteProductResult>;

public record DeleteProductResult(bool isSuccess);

public class DeleteProductCommandHandler(IDocumentSession session, ILogger<DeleteProductCommandHandler> logger)
    : ICommandHandler<DeleteProductCommand, DeleteProductResult>
{
    public async Task<DeleteProductResult> Handle(DeleteProductCommand command, CancellationToken cancellationToken)
    {
        logger.LogInformation("DeleteProductCommandHandler.Handle was called {command}", command);

        var product = await session.LoadAsync<Product>(command.Id, cancellationToken);
        if (product is null)
        {
            throw new ProductNotFoundException();
        }
        session.Delete<Product>(command.Id);
        await session.SaveChangesAsync(cancellationToken);
        
        return new DeleteProductResult(true);;
    }
}