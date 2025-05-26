using Microsoft.EntityFrameworkCore;
using OneContextExample.Couriers.Application.Services;
using OneContextExample.Couriers.Contracts.Queries;
using OneContextExample.Infrastructure.DataAccess;
using OneContextExample.Infrastructure.DataAccess.Couriers;

namespace OneContextExample.Couriers.Infrastructure.Services;

internal class CourierSelector(DataContext context) : ICourierSelector
{
    public async Task<IReadOnlyCollection<GetCouriersItemResult>> GetCouriers(CancellationToken cancellationToken = default)
    {
        return await context.Couriers.AsNoTracking().Select(x => new GetCouriersItemResult(
            x.Id,
            x.Name,
            x.CurrentOrder != null
                ? new GetCouriersItemResult.CurrentOrderResult(
                    x.CurrentOrder.Id,
                    x.CurrentOrder.Sum,
                    x.CurrentOrder.Status)
                : null)).ToArrayAsync(cancellationToken);
    }

    public async Task<GetCourierResult?> GetCourier(Guid id, CancellationToken cancellationToken = default)
    {
        return await context.Couriers.AsNoTracking().Select(x => new GetCourierResult(
            x.Id,
            x.Name,
            x.CurrentOrder != null
                ? new GetCourierResult.CurrentOrderResult(
                    x.CurrentOrder.Id,
                    x.CurrentOrder.Sum,
                    x.CurrentOrder.Status)
                : null)).FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }
}