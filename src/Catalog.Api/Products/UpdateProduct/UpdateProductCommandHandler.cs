using BuildingBlocks.Common.Response;
using Catalog.Api.Exceptions;
using Catalog.Api.Models.Products;
using Catalog.Api.Products.CreateProduct;
using Marten.Exceptions;

namespace Catalog.Api.Products.UpdateProduct;

public record UpdateProductCommand(
    Guid Id,
    string Name,
    List<string> Category,
    string Description,
    string ImageFile,
    decimal Price)
    : ICommand<Result>;

public record UpdateProductResult(bool IsSuccess);

internal class UpdateProductCommandHandler(IDocumentSession session)
    : ICommandHandler<UpdateProductCommand, Result>
{
    public async Task<Result> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
    {
        var product = await session.LoadAsync<Product>(command.Id, cancellationToken);

        if (product is null)
        {
            Result.Failure(ProductErrors.ProductNotFoundError);
        }

        product = Product.UpdateProduct(
            command.Id,
            command.Name,
            command.Description,
            command.ImageFile,
            command.Price,
            command.Category).Data;

        session.Update(product);
        await session.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}