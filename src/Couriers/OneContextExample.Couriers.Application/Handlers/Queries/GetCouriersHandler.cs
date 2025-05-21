using JetBrains.Annotations;
using Mediator;
using OneContextExample.Couriers.Application.Services;
using OneContextExample.Couriers.Contracts.Queries;

namespace OneContextExample.Couriers.Application.Handlers.Queries;

[UsedImplicitly]
public class GetCouriersHandler(ICourierSelector dataSelector) : IQueryHandler<GetCouriersQuery, IReadOnlyCollection<GetCouriersItemViewModel>>
{
    public async ValueTask<IReadOnlyCollection<GetCouriersItemViewModel>> Handle(GetCouriersQuery query, CancellationToken cancellationToken)
    {
        var result = await dataSelector.GetCouriers(cancellationToken);
        return result;
    }
}