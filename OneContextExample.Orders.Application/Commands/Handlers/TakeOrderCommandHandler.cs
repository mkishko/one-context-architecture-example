using Mediator;
using OneContextExample.Orders.Domain;

namespace OneContextExample.Orders.Application.Commands.Handlers;

public class TakeOrderCommandHandler(IOrdersRepository repository) : ICommandHandler<TakeOrderCommand>
{
    public async ValueTask<Unit> Handle(TakeOrderCommand command, CancellationToken cancellationToken)
    {
        var order = await repository.Get(command.OrderId, cancellationToken)
            ?? throw new InvalidOperationException("Order not found");
        
        order.TakeOrder();
        await repository.Save(order, cancellationToken);
        return Unit.Value;
    }
}