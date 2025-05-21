using JetBrains.Annotations;
using Mediator;
using OneContextExample.Orders.Application.Services;
using OneContextExample.Orders.Contracts.Queries;

namespace OneContextExample.Orders.Application.Handlers.Queries;

[UsedImplicitly]
public class GetOrdersHandler(IOrderSelector dataSelector) : IQueryHandler<GetOrderQuery, GetOrderViewModel?>
{
    public async ValueTask<GetOrderViewModel?> Handle(GetOrderQuery query, CancellationToken cancellationToken)
    {
        var result = await dataSelector.GetOrderAsViewModel(query.Id, cancellationToken);
        return result;
    }
}