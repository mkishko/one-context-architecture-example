using JetBrains.Annotations;
using Mediator;
using OneContextExample.Orders.Application.Services;
using OneContextExample.Orders.Contracts.Queries;

namespace OneContextExample.Orders.Application.Handlers.Queries;

[UsedImplicitly]
public class CanOrderBeTakenQueryHandler(IOrderSelector selector) : IQueryHandler<CanOrderBeTakenQuery, CanOrderBeTakenViewModel>
{
    public async ValueTask<CanOrderBeTakenViewModel> Handle(CanOrderBeTakenQuery beTakenQuery, CancellationToken cancellationToken)
    {
        var order = await selector.GetOrderAsEntity(beTakenQuery.OrderId, cancellationToken);
        return new CanOrderBeTakenViewModel(order?.CanBeTaken ?? false);
    }
}