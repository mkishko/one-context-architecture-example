using Mediator;
using OneContextExample.Couriers.Application.Commands.Services;
using OneContextExample.Orders.Application.Queries;

namespace OneContextExample.Infrastructure.Couriers.Adapters;

public class OrdersAccessorAdapter(ISender mediator) : IOrdersAccessor
{
    public async Task<bool> CanBeTaken(Guid id, CancellationToken cancellationToken = default)
    {
        var response = await mediator.Send(new CanOrderBeTakenQuery(id), cancellationToken);
        return response.Result;
    }
}