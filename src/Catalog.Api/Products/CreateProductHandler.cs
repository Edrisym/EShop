using BuildingBlocks.CQRS;
namespace Catalog.Api.Products;

public sealed record CreateProductCommand(
    string Name,
    string Description,
    string ImageFile,
    List<string> Category,
    decimal Price
) : ICommand<CreateProductResult>;

public record CreateProductResult(Guid Id);

public class CreateProductHandler : ICommandHandler<CreateProductCommand, CreateProductResult>
{
    public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
    {
        var product = Models.Products.CreateProducts(command.Name,
            command.Description,
            command.ImageFile,
            command.Price,
            command.Category);
        //Todo 
        //Save to the database
        return  new CreateProductResult(Guid.NewGuid());
    }
}