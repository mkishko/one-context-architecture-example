using JetBrains.Annotations;
using Mediator;
using OneContextExample.Couriers.Application.Services;
using OneContextExample.Couriers.Contracts.Queries;

namespace OneContextExample.Couriers.Application.Handlers.Queries;

[UsedImplicitly]
public class GetCouriersQueryHandler(ICourierSelector dataSelector) : IQueryHandler<GetCouriersQuery, IReadOnlyCollection<GetCouriersItemResult>>
{
    public async ValueTask<IReadOnlyCollection<GetCouriersItemResult>> Handle(GetCouriersQuery query, CancellationToken cancellationToken)
    {
        var result = await dataSelector.GetCouriers(cancellationToken);
        return result;
    }
}