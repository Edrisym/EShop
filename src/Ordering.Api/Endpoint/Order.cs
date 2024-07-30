using System.Reflection.Metadata.Ecma335;
using BuildingBlocks.Core.ApiResultWrapper;
using BuildingBlocks.Pagination;
using Mapster;
using MediatR;
using Ordering.Application.Dtos;
using Ordering.Application.Orders.Queries.GetOrders;
using Ordering.Application.Orders.Queries.GetOrdersByCustomer;
using Ordering.Application.Orders.Queries.GetOrdersByName;

namespace Ordering.Api.Endpoint;

public sealed record OrderResponse(Guid Id);

public sealed record OrderResponsePaginatedResponse(PaginatedResult<OrderDto> Order);

public sealed record OrderRequest(OrderDto OrderDto);

public sealed record GetOrdersByNameResponse(IQueryable<OrderDto> OrderDto);

public sealed record GetOrdersByNameCustomer(IQueryable<OrderDto> OrderDto);

public static class Order
{
    public static void RegisterUserEndpoints(this IEndpointRouteBuilder routes)
    {
        var users = routes.MapGroup("/api/v1/order");

        users.MapGet("", async (OrderRequest request, ISender sender) =>
            {
                var command = request.Adapt<OrderRequest>();
                var result = await sender.Send(command);
                var response = result.Adapt<OrderResponse>();

                return Results.Created($" /orders/{response.Id}", response);
            }).WithName("CreateOrder")
            .Produces<OrderResponse>(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Create Order")
            .WithDescription("Create Order");


        users.MapPut("", async (OrderRequest request, ISender sender) =>
            {
                var command = request.Adapt<OrderRequest>();
                var result = await sender.Send(command);
                var isUpdated = result.Adapt<bool>();

                return Results.Created($" /orders/{isUpdated}", isUpdated);
            }).WithName("UpdateOrder")
            .Produces<bool>(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Update Order")
            .WithDescription("Update Order");


        users.MapDelete("/{id}", async (Guid id, ISender sender) =>
            {
                var result = await sender.Send(id);
                var isDeleted = result.Adapt<bool>();

                return Results.Created($" /orders/{isDeleted}", isDeleted);
            }).WithName("DeleteOrder")
            .Produces<bool>(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Delete Order")
            .WithDescription("Delete Order");


        users.MapGet("/orderName", async (string orderName, ISender sender) =>
            {
                var result = await sender.Send(new GetOrdersByNameQuery(orderName));
                var response = result.Adapt<GetOrdersByNameResponse>();
                return Results.Ok(response);
            }).WithName("GetOrderByName")
            .Produces<bool>(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Get Order By Name")
            .WithDescription("Get Order By Name");


        users.MapGet("/customer", async (Guid customerId, ISender sender) =>
            {
                var result = await sender.Send(new GetOrdersByCustomerQuery(customerId));
                var response = result.Adapt<GetOrdersByNameResponse>();
                return Results.Ok(response);
            }).WithName("GetOrderByCustomer")
            .Produces<bool>(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Get Order By Customer")
            .WithDescription("Get Order By Customer");


        users.MapGet("/Orders", async (
                [AsParameters] PaginationRequest request,
                ISender sender) =>
            {
                var command = request.Adapt(new GetOrdersQuery(request));
                var result = await sender.Send(command);
                var response = result.Adapt<OrderResponsePaginatedResponse>();

                return Results.Ok(response);
            }).WithName("CreateOrder")
            .Produces<OrderResponse>(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Create Order")
            .WithDescription("Create Order");
    }
}