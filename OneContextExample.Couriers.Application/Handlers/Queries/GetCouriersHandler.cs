using JetBrains.Annotations;
using Mediator;
using OneContextExample.Couriers.Application.Services;
using OneContextExample.Couriers.Contracts.Queries;
using OneContextExample.Couriers.Contracts.Queries.Models;

namespace OneContextExample.Couriers.Application.Handlers.Queries;

[UsedImplicitly]
public class GetCouriersHandler(ICouriersSelector dataSelector) : IQueryHandler<GetCouriersQuery, IReadOnlyCollection<GetCourierResponse>>
{
    public async ValueTask<IReadOnlyCollection<GetCourierResponse>> Handle(GetCouriersQuery query, CancellationToken cancellationToken)
    {
        var result = await dataSelector.GetCouriers(cancellationToken);
        return result;
    }
}