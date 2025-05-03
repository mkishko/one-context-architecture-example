using JetBrains.Annotations;
using Mediator;
using OneContextExample.Orders.Application.Queries.Models;
using OneContextExample.Orders.Application.Queries.Services;

namespace OneContextExample.Orders.Application.Queries.Handlers;

[UsedImplicitly]
public class CanOrderBeTakenQueryHandler(IOrdersExtractor extractor) : IQueryHandler<CanOrderBeTakenQuery, CanOrderBeTakenResponse>
{
    public async ValueTask<CanOrderBeTakenResponse> Handle(CanOrderBeTakenQuery beTakenQuery, CancellationToken cancellationToken)
    {
        var order = await extractor.GetOrder(beTakenQuery.OrderId, cancellationToken);
        return new CanOrderBeTakenResponse(order?.CanBeTaken ?? false);
    }
}