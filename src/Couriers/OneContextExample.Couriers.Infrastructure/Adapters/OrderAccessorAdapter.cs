using Mediator;
using OneContextExample.Couriers.Application.Services;
using OneContextExample.Orders.Contracts.Commands;
using OneContextExample.Orders.Contracts.Queries;

namespace OneContextExample.Couriers.Infrastructure.Adapters;

public class OrderAccessorAdapter(ISender mediator) : IOrderAccessor
{
    public async Task<bool> CanBeTaken(Guid id, CancellationToken cancellationToken = default)
    {
        var response = await mediator.Send(new CanOrderBeTakenQuery(id), cancellationToken);
        return response.Result;
    }

    public async Task TakeOrder(Guid id, CancellationToken cancellationToken = default)
    {
        await mediator.Send(new TakeOrderCommand(id), cancellationToken);
    }
}