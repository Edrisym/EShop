using BuildingBlocks.Pagination;

namespace Ordering.Application.Orders.Queries.GetOrders;

public record GetOrdersQuery(PaginationRequest PaginationRequest) 
    : IQuery<Result>;

public record GetOrdersResult(PaginatedResult<OrderDto> Orders);