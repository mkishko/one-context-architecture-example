using Mediator;

namespace OneContextExample.Orders.Contracts.Queries;

public record GetOrderQuery(Guid Id) : IQuery<GetOrderViewModel?>;