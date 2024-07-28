namespace Ordering.Application.Orders.Queries.GetOrdersByCustomer;

public record GetOrdersByCustomerQuery(Guid CustomerId)
    : IQuery<Result>;

public record GetOrdersByCustomerResult(IEnumerable<OrderDto> Orders);