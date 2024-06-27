using BuildingBlocks.ApiResultWrapper;
using Catalog.Api.Models.Products;

namespace Catalog.Api.Products.CreateProduct;

public sealed record CreateProductCommand(
    string Name,
    string Description,
    string ImageFile,
    List<string> Category,
    decimal Price
) : ICommand<Result>;

public record CreateProductResult(Guid Id);

public class CreateProductHandler(IDocumentSession _session, 
    IValidator<CreateProductCommand> _validator,
    ILogger<CreateProductHandler> logger)
    : ICommandHandler<CreateProductCommand, Result>
{
    public async Task<Result> Handle(CreateProductCommand command, CancellationToken cancellationToken)
    {
        logger.LogInformation($"CreateProductHandler.Handle was called {command}", command);

        var productExists = _session.LoadAsync<Product>(command.Name);

        if (productExists is null)
        {
            return Result.Failure(ProductErrors.DuplicatedProductError);
        }
        
        var product = Product.CreateProduct(
            command.Name,
            command.Description,
            command.ImageFile,
            command.Price,
            command.Category);
        
        _session.Store(product);
        await _session.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}