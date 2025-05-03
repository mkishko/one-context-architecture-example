using Mediator;
using OneContextExample.Couriers.Application.Queries.Models;

namespace OneContextExample.Couriers.Application.Queries;

public record GetCouriersQuery : IQuery<IReadOnlyCollection<GetCourierResponse>>;