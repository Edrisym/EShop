using BuildingBlocks.ApiResultWrapper;
using Catalog.Api.Models.Products;

namespace Catalog.Api.Products.GetProduct;

public sealed record GetProductQuery() : IQuery<Result<IReadOnlyCollection<Product>>>;

public sealed record GetProductResult(Result<IReadOnlyCollection<Product>> Products);

public class GetProductQueryHandler(IDocumentSession session, ILogger<GetProductQueryHandler> logger)
    : IQueryHandler<GetProductQuery, Result<IReadOnlyCollection<Product>>>
{
    public async Task<Result<IReadOnlyCollection<Product>>> Handle(GetProductQuery query,
        CancellationToken cancellationToken)
    {
        logger.LogInformation($"GetProductQueryHandler.Handle called with {query}", query);
        
        var products = await session
            .Query<Product>().ToListAsync(cancellationToken);
        
        return Result<IReadOnlyCollection<Product>>.Success(products);
    }
}