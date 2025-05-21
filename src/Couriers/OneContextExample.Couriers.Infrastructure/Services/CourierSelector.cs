using Microsoft.EntityFrameworkCore;
using OneContextExample.Couriers.Application.Services;
using OneContextExample.Couriers.Contracts.Queries;
using OneContextExample.Infrastructure.DataAccess;
using OneContextExample.Infrastructure.DataAccess.Couriers;

namespace OneContextExample.Couriers.Infrastructure.Services;

internal class CourierSelector(DataContext context) : ICourierSelector
{
    public async Task<IReadOnlyCollection<GetCouriersItemViewModel>> GetCouriers(CancellationToken cancellationToken = default)
    {
        return await GetCourierQuery(context.Couriers).ToArrayAsync(cancellationToken);
    }

    public async Task<GetCouriersItemViewModel?> GetCourier(Guid id, CancellationToken cancellationToken = default)
    {
        return await GetCourierQuery(context.Couriers).FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    private IQueryable<GetCouriersItemViewModel> GetCourierQuery(IQueryable<Courier> query)
    {
        return query.AsNoTracking().Select(x => new GetCouriersItemViewModel(
            x.Id,
            x.Name,
            x.CurrentOrder != null
                ? new GetCouriersItemViewModel.CurrentOrderDto(
                    x.CurrentOrder.Id,
                    x.CurrentOrder.Sum,
                    x.CurrentOrder.Status)
                : null));
    }
}