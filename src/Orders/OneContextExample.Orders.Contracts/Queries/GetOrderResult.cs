using OneContextExample.Core.Enums;

namespace OneContextExample.Orders.Contracts.Queries;

public record GetOrderResult(Guid Id, int Sum, OrderStatus Status);