namespace Catalog.Api.Products.CreateProduct;

public sealed record CreateProductCommand(
    string Name,
    string Description,
    string ImageFile,
    List<string> Category,
    decimal Price
) : ICommand<CreateProductResult>;

public record CreateProductResult(Guid Id);

public class CreateProductHandler(IDocumentSession session) 
    : ICommandHandler<CreateProductCommand, CreateProductResult>
{
    public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
    {
        var product = Models.Product.CreateProduct(
            command.Name,
            command.Description,
            command.ImageFile,
            command.Price,
            command.Category);
        
        session.Store(product);
        await session.SaveChangesAsync(cancellationToken);

        return new CreateProductResult(product.Id) ;
    }
}