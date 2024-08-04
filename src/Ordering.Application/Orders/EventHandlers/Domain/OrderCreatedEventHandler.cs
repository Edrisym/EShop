﻿using MassTransit;
using MediatR;
using Microsoft.Extensions.Logging;
using Microsoft.FeatureManagement;
using Ordering.Domain.Event;

namespace Ordering.Application.Orders.EventHandlers.Domain;

public class OrderCreatedEventHandler(
    ILogger<OrderCreatedEventHandler> logger)
    : INotificationHandler<OrderCreatedEvent>
{
    public async Task Handle(OrderCreatedEvent domainEvent, CancellationToken cancellationToken)
    {
        logger.LogInformation("Domain Event handled: {DomainEvent}", domainEvent.GetType().Name);
        //
        // if (await featureManager.IsEnabledAsync("OrderFulfillment"))
        // {
        //     var orderCreatedIntegrationEvent = domainEvent.Order.ToOrderDto();
        //     await publishEndpoint.Publish(orderCreatedIntegrationEvent, cancellationToken);
        // }
    }
}