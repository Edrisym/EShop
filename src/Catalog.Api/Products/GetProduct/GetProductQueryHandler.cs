
namespace Catalog.Api.Products.GetProduct;

public sealed record GetProductQuery() : IQuery<GetProductResult>;

public sealed record GetProductResult(IReadOnlyCollection<Models.Products> Products);


public class GetProductQueryHandler : IQueryHandler<GetProductQuery, GetProductResult>
{
    public Task<GetProductResult> Handle(GetProductQuery request, CancellationToken cancellationToken)
    {
        
    }
}