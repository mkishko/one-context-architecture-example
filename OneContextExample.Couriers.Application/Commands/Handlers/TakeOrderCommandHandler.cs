using Mediator;
using OneContextExample.Couriers.Application.Commands.Services;

namespace OneContextExample.Couriers.Application.Commands.Handlers;

public class TakeOrderCommandHandler(
    ICouriersPreserver couriersPreserver,
    IOrdersAccessor ordersAccessor)
    : ICommandHandler<TakeOrderCommand, bool>
{
    public async ValueTask<bool> Handle(TakeOrderCommand command, CancellationToken cancellationToken)
    {
        var courier = await couriersPreserver.Get(command.CourierId, cancellationToken)
            ?? throw new InvalidOperationException("Courier not found");
        var orderCanBeTaken = await ordersAccessor.CanBeTaken(command.OrderId, cancellationToken);

        if (!courier.IsBusy && orderCanBeTaken)
        {
            courier.TakeOrder(command.OrderId);
            await couriersPreserver.Save(courier, cancellationToken);
            return true;
        }

        return false;
    }
}