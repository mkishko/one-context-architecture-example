using Microsoft.EntityFrameworkCore;
using OneContextExample.Infrastructure.Data;
using OneContextExample.Orders.Application.Queries.Services;
using OneContextExample.Orders.Domain;

namespace OneContextExample.Infrastructure.Orders.Services;

internal class OrdersExtractor(DataContext context) : IOrdersExtractor
{
    public async Task<Order?> GetOrder(Guid id, CancellationToken cancellationToken = default)
    {
        var order = await context.Orders
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        return order?.ToEntity();
    }
}