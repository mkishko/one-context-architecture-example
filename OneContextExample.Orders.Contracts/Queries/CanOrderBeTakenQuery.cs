using Mediator;
using OneContextExample.Orders.Contracts.Queries.Models;

namespace OneContextExample.Orders.Contracts.Queries;

public record CanOrderBeTakenQuery(Guid OrderId) : IQuery<CanOrderBeTakenResponse>;