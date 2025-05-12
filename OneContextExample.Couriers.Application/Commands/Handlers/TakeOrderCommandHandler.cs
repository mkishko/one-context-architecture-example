using Mediator;
using OneContextExample.Couriers.Application.Services;
using OneContextExample.Couriers.Domain;

namespace OneContextExample.Couriers.Application.Commands.Handlers;

public class TakeOrderCommandHandler(
    ICouriersRepository couriersRepository,
    IOrdersAccessor ordersAccessor)
    : ICommandHandler<TakeOrderCommand, bool>
{
    public async ValueTask<bool> Handle(TakeOrderCommand command, CancellationToken cancellationToken)
    {
        var courier = await couriersRepository.Get(command.CourierId, cancellationToken)
            ?? throw new InvalidOperationException("Courier not found");
        var orderCanBeTaken = await ordersAccessor.CanBeTaken(command.OrderId, cancellationToken);

        if (!courier.IsBusy && orderCanBeTaken)
        {
            courier.TakeOrder(command.OrderId);
            await couriersRepository.Save(courier, cancellationToken);
            return true;
        }

        return false;
    }
}