using Mediator;

namespace OneContextExample.Couriers.Contracts.Queries;

public record GetCouriersQuery : IQuery<IReadOnlyCollection<GetCouriersItemViewModel>>;