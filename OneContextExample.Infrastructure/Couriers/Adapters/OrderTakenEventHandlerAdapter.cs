using Mediator;
using OneContextExample.Couriers.Domain.Events;
using OneContextExample.Orders.Application.Commands;

namespace OneContextExample.Infrastructure.Couriers.Adapters;

public class OrderTakenEventHandlerAdapter(ISender sender) : INotificationHandler<OrderTakenEvent>
{
    public async ValueTask Handle(OrderTakenEvent notification, CancellationToken cancellationToken)
    {
        await sender.Send(new TakeOrderCommand(notification.OrderId), cancellationToken);
    }
}