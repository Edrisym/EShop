using MediatR;

namespace BuildingBlocks.CQRS;

public interface IQuery<out TResponse> : IRequest
    where TResponse : notnull
{
}