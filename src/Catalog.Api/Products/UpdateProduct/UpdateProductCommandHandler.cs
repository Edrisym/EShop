using Catalog.Api.Exceptions;
using Catalog.Api.Models;

namespace Catalog.Api.Products.UpdateProduct;

public sealed record UpdateProductCommand(
    Guid Id,
    string name,
    string description,
    string imageFile,
    decimal price,
    List<string> category) : ICommand<UpdateProductResult>;

public sealed record UpdateProductResult(bool IsSuccess);

public class UpdateProductCommandHandler(IDocumentSession session, ILogger logger)
    : ICommandHandler<UpdateProductCommand, UpdateProductResult>
{
    public async Task<UpdateProductResult> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
    {
        var product = await session.LoadAsync<Product>(command.Id, cancellationToken);

        //TODO
        // result pattern
        if (product is null)
        {
            throw new ProductNotFoundException();
        }

        var updatedProduct = Product.UpdateProduct(product.Name,
            product.Description,
            product.ImageFile,
            product.Price,
            product.Category);
        
        session.Update(updatedProduct);
        await session.SaveChangesAsync(cancellationToken);
        
        return new UpdateProductResult(true);
    }
}