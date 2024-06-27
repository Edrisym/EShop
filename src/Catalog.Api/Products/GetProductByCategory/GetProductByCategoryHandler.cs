using Catalog.Api.Models.Products;

namespace Catalog.Api.Products.GetProductByCategory;

public sealed record GetProductByCategoryQuery(string category) : IQuery<GetProductByCategoryResult>;

public sealed record GetProductByCategoryResult(IReadOnlyCollection<Product> Products);

public class GetProductByCategoryHandler(IDocumentSession session, ILogger<GetProductByCategoryHandler> logger)
    : IQueryHandler<GetProductByCategoryQuery, GetProductByCategoryResult>
{
    public async Task<GetProductByCategoryResult> Handle(GetProductByCategoryQuery query,
        CancellationToken cancellationToken)
    {
        logger.LogInformation("GetProductByCategoryHandler.Handle was called with {query}", query);

        var result = await session.Query<Product>()
            .Where(x => x.Category.Contains(query.category))
            .ToListAsync(cancellationToken);

        return new GetProductByCategoryResult(result);
    }
}