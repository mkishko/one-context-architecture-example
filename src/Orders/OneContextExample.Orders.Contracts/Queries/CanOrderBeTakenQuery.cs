using Mediator;

namespace OneContextExample.Orders.Contracts.Queries;

public record CanOrderBeTakenQuery(Guid OrderId) : IQuery<CanOrderBeTakenViewModel>;