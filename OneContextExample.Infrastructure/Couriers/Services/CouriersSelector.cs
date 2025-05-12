using Microsoft.EntityFrameworkCore;
using OneContextExample.Couriers.Application.Queries.Models;
using OneContextExample.Couriers.Application.Services;
using OneContextExample.Infrastructure.Data;
using OneContextExample.Infrastructure.Data.Couriers;

namespace OneContextExample.Infrastructure.Couriers.Services;

internal class CouriersSelector(DataContext context) : ICouriersSelector
{
    public async Task<IReadOnlyCollection<GetCourierResponse>> GetCouriers(CancellationToken cancellationToken = default)
    {
        return await GetCourierQuery(context.Couriers).ToArrayAsync(cancellationToken);
    }

    public async Task<GetCourierResponse?> GetCourier(Guid id, CancellationToken cancellationToken = default)
    {
        return await GetCourierQuery(context.Couriers).FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    private IQueryable<GetCourierResponse> GetCourierQuery(IQueryable<Courier> query)
    {
        return query.AsNoTracking().Select(x => new GetCourierResponse(
            x.Id,
            x.Name,
            x.CurrentOrder != null
                ? new GetCourierResponse.CurrentOrderDto(
                    x.CurrentOrder.Id,
                    x.CurrentOrder.Sum,
                    x.CurrentOrder.Status)
                : null));
    }
}