using Catalog.Api.Products.Commands;
using MediatR;

namespace Catalog.Api.Products;

public class CreateProductEndPoint : IRequestHandler<CreateProductCommand, CreateProductResult>
{
    public Task<CreateProductResult> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}