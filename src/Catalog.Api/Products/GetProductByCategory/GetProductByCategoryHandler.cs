using BuildingBlocks.ApiResultWrapper;
using Catalog.Api.Models.Products;

namespace Catalog.Api.Products.GetProductByCategory;

public sealed record GetProductByCategoryQuery(string category) : IQuery<Result<IReadOnlyCollection<Product>>>;

public sealed record GetProductByCategoryResult(Result<IReadOnlyCollection<Product>> Products);

public class GetProductByCategoryHandler(IDocumentSession session, ILogger<GetProductByCategoryHandler> logger)
    : IQueryHandler<GetProductByCategoryQuery, Result<IReadOnlyCollection<Product>>>
{
    public async Task<Result<IReadOnlyCollection<Product>>> Handle(GetProductByCategoryQuery query,
        CancellationToken cancellationToken)
    {
        logger.LogInformation("GetProductByCategoryHandler.Handle was called with {query}", query);

        var result = await session.Query<Product>()
            .Where(x => x.Category.Contains(query.category))
            .ToListAsync(cancellationToken);

        return Result<IReadOnlyCollection<Product>>.Success(result);
    }
}