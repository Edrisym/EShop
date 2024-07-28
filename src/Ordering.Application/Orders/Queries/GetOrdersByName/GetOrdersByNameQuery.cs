namespace Ordering.Application.Orders.Queries.GetOrdersByName;

public record GetOrdersByNameQuery(string Name)
    : IQuery<Result>;

public record GetOrdersByNameResult(IEnumerable<OrderDto> Orders);