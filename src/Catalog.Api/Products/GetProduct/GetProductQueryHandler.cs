using System.Runtime.InteropServices.JavaScript;
using BuildingBlocks.ApiResultWrapper;
using BuildingBlocks.Common.Response;
using Catalog.Api.Models.Products;
using Marten.Pagination;

namespace Catalog.Api.Products.GetProduct;

public sealed record GetProductQuery(int PageNumber, int PageSize)
    : IQuery<Result>;

public sealed record GetProductResult(Result Products);

public class GetProductQueryHandler(IDocumentSession session)
    : IQueryHandler<GetProductQuery, Result>
{
    public async Task<Result> Handle(GetProductQuery query,
        CancellationToken cancellationToken)
    {
        var products = await session
            .Query<Product>()
            .ToPagedListAsync(
                query.PageNumber,
                query.PageSize,
                cancellationToken);

        if (!products.Any())
        {
            return Result.Failure(Error.ValueNotFound);
        }

        return Result.Success(products);
    }
}