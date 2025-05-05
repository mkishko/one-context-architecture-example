using Mediator;
using OneContextExample.Couriers.Application.Commands.Services;
using OneContextExample.Couriers.Domain.Events;

namespace OneContextExample.Couriers.Application.Commands.Handlers;

public class OrderTakenEventHandler(IOrdersAccessor accessor) : INotificationHandler<OrderTakenEvent>
{
    public async ValueTask Handle(OrderTakenEvent notification, CancellationToken cancellationToken)
    {
        await accessor.TakeOrder(notification.OrderId, cancellationToken);
    }
}