using MediatR;

namespace Catalog.Api.Products.Commands;

public record CreateProductCommand(
    string name,
    string description,
    string imgaeFile,
    List<string> category,
    decimal price
) : IRequest<CreateProductResult>;

public record CreateProductResult(Guid Id);