using Microsoft.EntityFrameworkCore;
using OneContextExample.Infrastructure.DataAccess;
using OneContextExample.Orders.Application.Services;
using OneContextExample.Orders.Domain;

namespace OneContextExample.Orders.Infrastructure.Services;

internal class OrderSelector(DataContext context) : IOrderSelector
{
    public async Task<Order?> GetOrder(Guid id, CancellationToken cancellationToken = default)
    {
        var order = await context.Orders
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        return order?.ToEntity();
    }
}