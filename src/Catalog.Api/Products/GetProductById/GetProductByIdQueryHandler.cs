using BuildingBlocks.ApiResultWrapper;
using Catalog.Api.Exceptions;
using Catalog.Api.Models.Products;
using Catalog.Api.Products.CreateProduct;
using Catalog.Api.Products.GetProduct;

namespace Catalog.Api.Products.GetProductById;

public sealed record GetProductByIdQuery(Guid Id) : IQuery<Result<Product>>;

public sealed record GetProductByIdRequest(Result<Product> Product);

public class GetProductByIdQueryHandler(IDocumentSession session)
    : IQueryHandler<GetProductByIdQuery, Result<Product>>
{
    public async Task<Result<Product>> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
    {
        var product = await session.LoadAsync<Product>(query.Id, cancellationToken);
        if (product is null)
        {
            return Result.Failure<Product>(ProductErrors.ProductNotFoundError);
        }

        return Result<Product>.Success(product);
    }
}