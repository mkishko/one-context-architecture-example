using JetBrains.Annotations;
using Mediator;
using OneContextExample.Couriers.Application.Services;
using OneContextExample.Couriers.Contracts.Commands;
using OneContextExample.Couriers.Domain;

namespace OneContextExample.Couriers.Application.Handlers.Commands;

[UsedImplicitly]
public class TakeOrderCommandHandler(
    ICourierRepository courierRepository,
    IOrderAccessor orderAccessor)
    : ICommandHandler<TakeOrderCommand, bool>
{
    public async ValueTask<bool> Handle(TakeOrderCommand command, CancellationToken cancellationToken)
    {
        var courier = await courierRepository.Get(command.CourierId, cancellationToken)
            ?? throw new InvalidOperationException("Courier not found");
        var orderCanBeTaken = await orderAccessor.CanBeTaken(command.OrderId, cancellationToken);
        
        if (!courier.IsBusy && orderCanBeTaken)
        {
            courier.TakeOrder(command.OrderId);
            await courierRepository.Save(courier, cancellationToken);
            return true;
        }

        return false;
    }
}