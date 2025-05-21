using OneContextExample.Core.Enums;

namespace OneContextExample.Orders.Contracts.Queries;

public record GetOrderViewModel(Guid Id, int Sum, OrderStatus Status);