namespace Catalog.Api.Products.DeleteProduct;

public sealed record DeleteProductCommand(Guid Id) 
    : ICommand<DeleteProductResult>;

public sealed record DeleteProductResult(bool isSuccess);

public class DeleteProductCommandHandler() : ICommandHandler<DeleteProductCommand, DeleteProductResult>
{
    public Task<DeleteProductResult> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        
    }
}