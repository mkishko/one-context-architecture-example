using Mediator;
using OneContextExample.Orders.Application.Queries.Models;

namespace OneContextExample.Orders.Application.Queries;

public record CanOrderBeTakenQuery(Guid OrderId) : IQuery<CanOrderBeTakenResponse>;