using Mediator;
using OneContextExample.Core;
using OneContextExample.Couriers.Application.IntegrationEvents;
using OneContextExample.Couriers.Application.Services;
using OneContextExample.Couriers.Domain.Events;

namespace OneContextExample.Couriers.Application.Handlers.DomainEvents;

public class OrderTakenEventHandler(IOrderAccessor accessor, IIntegrationEventPublisher eventPublisher) : INotificationHandler<OrderTakenEvent>
{
    public async ValueTask Handle(OrderTakenEvent @event, CancellationToken cancellationToken)
    {
        await eventPublisher.Publish(new CourierTookOrder(
            Guid.CreateVersion7(),
            @event.CourierId,
            @event.OrderId,
            1), cancellationToken);

        await accessor.TakeOrder(@event.OrderId, cancellationToken);
    }
}