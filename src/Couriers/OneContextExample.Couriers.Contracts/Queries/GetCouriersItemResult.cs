using OneContextExample.Core.Enums;

namespace OneContextExample.Couriers.Contracts.Queries;

/// <summary>
/// Represents the result of a query to retrieve a courier item.
/// </summary>
/// <param name="Id">The unique identifier of the courier.</param>
/// <param name="Name">The name of the courier.</param>
/// <param name="CurrentOrder">The current order of the courier.</param>
public record GetCouriersItemResult(Guid Id, string Name, GetCouriersItemResult.CurrentOrderResult? CurrentOrder)
{
    public record CurrentOrderResult(Guid Id, int Sum, OrderStatus Status);
}