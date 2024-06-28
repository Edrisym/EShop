using BuildingBlocks.ApiResultWrapper;
using BuildingBlocks.Common.Response;
using Catalog.Api.Models.Products;

namespace Catalog.Api.Products.GetProductByCategory;

public sealed record GetProductByCategoryQuery(string category) : IQuery<Result<IReadOnlyCollection<Product>>>;

public sealed record GetProductByCategoryResult(Result<IReadOnlyCollection<Product>> Products);

public class GetProductByCategoryHandler(IDocumentSession session)
    : IQueryHandler<GetProductByCategoryQuery, Result<IReadOnlyCollection<Product>>>
{
    public async Task<Result<IReadOnlyCollection<Product>>> Handle(GetProductByCategoryQuery query,
        CancellationToken cancellationToken)
    {
        var products = await session.Query<Product>()
            .Where(x => x.Category.Contains(query.category))
            .ToListAsync(cancellationToken);

        if (products.Count == 0)
        {
            return Result.Failure<IReadOnlyCollection<Product>>(Error.ValueNotFound);
        }

        return Result<IReadOnlyCollection<Product>>.Success(products);
    }
}