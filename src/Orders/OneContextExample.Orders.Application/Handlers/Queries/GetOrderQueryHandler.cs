using JetBrains.Annotations;
using Mediator;
using OneContextExample.Orders.Application.Services;
using OneContextExample.Orders.Contracts.Queries;

namespace OneContextExample.Orders.Application.Handlers.Queries;

[UsedImplicitly]
public class GetOrderQueryHandler(IOrderSelector dataSelector) : IQueryHandler<GetOrderQuery, GetOrderResult?>
{
    public async ValueTask<GetOrderResult?> Handle(GetOrderQuery query, CancellationToken cancellationToken)
    {
        var result = await dataSelector.GetOrderAsViewModel(query.Id, cancellationToken);
        return result;
    }
}