using JetBrains.Annotations;
using Mediator;
using OneContextExample.Orders.Application.Services;
using OneContextExample.Orders.Contracts.Queries;
using OneContextExample.Orders.Contracts.Queries.Models;

namespace OneContextExample.Orders.Application.Handlers.Queries;

[UsedImplicitly]
public class CanOrderBeTakenQueryHandler(IOrdersSelector selector) : IQueryHandler<CanOrderBeTakenQuery, CanOrderBeTakenResponse>
{
    public async ValueTask<CanOrderBeTakenResponse> Handle(CanOrderBeTakenQuery beTakenQuery, CancellationToken cancellationToken)
    {
        var order = await selector.GetOrder(beTakenQuery.OrderId, cancellationToken);
        return new CanOrderBeTakenResponse(order?.CanBeTaken ?? false);
    }
}