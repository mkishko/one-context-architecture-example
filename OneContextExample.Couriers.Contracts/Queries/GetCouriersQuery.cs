using Mediator;
using OneContextExample.Couriers.Contracts.Queries.Models;

namespace OneContextExample.Couriers.Contracts.Queries;

public record GetCouriersQuery : IQuery<IReadOnlyCollection<GetCourierResponse>>;