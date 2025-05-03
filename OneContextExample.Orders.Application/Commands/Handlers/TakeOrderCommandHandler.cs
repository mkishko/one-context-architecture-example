using Mediator;
using OneContextExample.Orders.Application.Commands.Services;

namespace OneContextExample.Orders.Application.Commands.Handlers;

public class TakeOrderCommandHandler(IOrdersPreserver preserver) : ICommandHandler<TakeOrderCommand>
{
    public async ValueTask<Unit> Handle(TakeOrderCommand command, CancellationToken cancellationToken)
    {
        var order = await preserver.Get(command.OrderId, cancellationToken)
            ?? throw new InvalidOperationException("Order not found");
        
        order.TakeOrder();
        await preserver.Save(order, cancellationToken);
        return Unit.Value;
    }
}