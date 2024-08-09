using Basket.API.Dtos;
using BuildingBlocks.Messaging.Events;
using Mapster;
using MassTransit;

namespace Basket.API.Basket.CheckoutBasket;

public record CheckoutBasketCommand(BasketCheckoutDto BasketCheckoutDto)
    : ICommand<Result>;

public class CheckoutBasketCommandHandler(IBasketRepository repository, IPublishEndpoint publishEndpoint)
    : ICommandHandler<CheckoutBasketCommand, Result>
{
    public async Task<Result> Handle(CheckoutBasketCommand command, CancellationToken cancellationToken)
    {
        var basket = await repository
            .GetBasket(command.BasketCheckoutDto.UserName, cancellationToken);

        if (basket is null)
        {
            return Result.Success(Error.ValueNotFound);
        }

        var eventMessage = command.BasketCheckoutDto.Adapt<BasketCheckoutEvent>();
        eventMessage.TotalPrice = basket.TotalPrice;

        await publishEndpoint.Publish(eventMessage, cancellationToken);

        await repository.DeleteBasket(command.BasketCheckoutDto.UserName, cancellationToken);

        return Result.Success();
    }
}