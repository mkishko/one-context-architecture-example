using Microsoft.EntityFrameworkCore;
using OneContextExample.Infrastructure.DataAccess;
using OneContextExample.Orders.Application.Services;
using OneContextExample.Orders.Contracts.Queries;

namespace OneContextExample.Orders.Infrastructure.Services;

internal class OrderSelector(DataContext context) : IOrderSelector
{
    public async Task<Domain.Order?> GetOrderAsEntity(Guid id, CancellationToken cancellationToken = default)
    {
        var order = await context.Orders
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        return order?.ToEntity();
    }

    public async Task<GetOrderViewModel?> GetOrderAsViewModel(Guid id, CancellationToken cancellationToken = default)
    {
        return await context.Orders
            .AsNoTracking()
            .Select(o => new GetOrderViewModel(o.Id, o.Sum, o.Status))
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }
}