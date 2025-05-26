using JetBrains.Annotations;
using Mediator;
using OneContextExample.Orders.Contracts.Queries;
using OneContextExample.Orders.Domain;

namespace OneContextExample.Orders.Application.Handlers.Queries;

[UsedImplicitly]
public class CanOrderBeTakenQueryHandler(IOrderRepository repository) : IQueryHandler<CanOrderBeTakenQuery, CanOrderBeTakenResult>
{
    public async ValueTask<CanOrderBeTakenResult> Handle(CanOrderBeTakenQuery beTakenQuery, CancellationToken cancellationToken)
    {
        var order = await repository.Get(beTakenQuery.OrderId, cancellationToken);
        return new CanOrderBeTakenResult(order?.CanBeTaken ?? false);
    }
}