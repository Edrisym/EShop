using Catalog.Api.Exceptions;
using Catalog.Api.Models.Products;
using Catalog.Api.Products.GetProduct;

namespace Catalog.Api.Products.GetProductById;

public sealed record GetProductByIdQuery(Guid Id) : IQuery<GetProductByIdRequest>;

public sealed record GetProductByIdRequest(Product Product);

public class GetProductByIdQueryHandler(IDocumentSession session, ILogger<GetProductQueryHandler> logger)
    : IQueryHandler<GetProductByIdQuery, GetProductByIdRequest>
{
    public async Task<GetProductByIdRequest> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
    {
        logger.LogInformation($"GetProductByIdQueryHandler.Handle Called with {query}");
        var product = await session.LoadAsync<Product>(query.Id, cancellationToken);
        if (product is null)
        {
            throw new ProductNotFoundException();
        }

        return new GetProductByIdRequest(product);
    }
}