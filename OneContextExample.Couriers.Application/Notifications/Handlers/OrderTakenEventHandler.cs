using Mediator;
using OneContextExample.Core;
using OneContextExample.Couriers.Application.Events;
using OneContextExample.Couriers.Application.Services;
using OneContextExample.Couriers.Domain.Events;

namespace OneContextExample.Couriers.Application.Notifications.Handlers;

public class OrderTakenEventHandler(IOrdersAccessor accessor, IIntegrationEventsPublisher eventsPublisher) : INotificationHandler<OrderTakenEvent>
{
    public async ValueTask Handle(OrderTakenEvent notification, CancellationToken cancellationToken)
    {
        await eventsPublisher.Publish(new CourierTookOrder(
            Guid.CreateVersion7(),
            notification.CourierId,
            notification.OrderId,
            1), cancellationToken);
        await accessor.TakeOrder(notification.OrderId, cancellationToken);
    }
}