using Mediator;

namespace OneContextExample.Couriers.Contracts.Queries;

/// <summary>
/// Represents a query to retrieve a collection of courier items.
/// </summary>
public record GetCouriersQuery : IQuery<IReadOnlyCollection<GetCouriersItemResult>>;