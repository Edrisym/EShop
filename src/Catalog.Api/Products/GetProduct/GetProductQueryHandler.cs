using Catalog.Api.Models.Products;

namespace Catalog.Api.Products.GetProduct;

public sealed record GetProductQuery() : IQuery<GetProductResult>;

public sealed record GetProductResult(IReadOnlyCollection<Product> Products);

public class GetProductQueryHandler(IDocumentSession session, ILogger<GetProductQueryHandler> logger)
    : IQueryHandler<GetProductQuery, GetProductResult>
{
    public async Task<GetProductResult> Handle(GetProductQuery query, CancellationToken cancellationToken)
    {
        logger.LogInformation($"GetProductQueryHandler.Handle called with {query}", query);
        var products = await session.Query<Product>().ToListAsync(cancellationToken);
        return new GetProductResult(products);
    }
}