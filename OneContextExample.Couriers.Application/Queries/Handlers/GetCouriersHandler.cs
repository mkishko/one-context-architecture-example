using JetBrains.Annotations;
using Mediator;
using OneContextExample.Couriers.Application.Queries.Models;
using OneContextExample.Couriers.Application.Services;

namespace OneContextExample.Couriers.Application.Queries.Handlers;

[UsedImplicitly]
public class GetCouriersHandler(ICouriersSelector dataSelector) : IQueryHandler<GetCouriersQuery, IReadOnlyCollection<GetCourierResponse>>
{
    public async ValueTask<IReadOnlyCollection<GetCourierResponse>> Handle(GetCouriersQuery query, CancellationToken cancellationToken)
    {
        var result = await dataSelector.GetCouriers(cancellationToken);
        return result;
    }
}