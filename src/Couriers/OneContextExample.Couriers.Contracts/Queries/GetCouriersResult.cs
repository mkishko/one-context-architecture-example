using OneContextExample.Core.Enums;

namespace OneContextExample.Couriers.Contracts.Queries;

/// <summary>
/// Represents the result of a query to retrieve a courier item.
/// </summary>
/// <param name="Id">The unique identifier of the courier.</param>
/// <param name="Name">The name of the courier.</param>
/// <param name="CurrentOrder">The current order of the courier.</param>
public record GetCourierResult(Guid Id, string Name, GetCourierResult.CurrentOrderResult? CurrentOrder)
{
    /// <summary>
    /// Represents the current order of a courier.
    /// </summary>
    /// <param name="Id">The unique identifier of the order.</param>
    /// <param name="Sum">The sum of the order.</param>
    /// <param name="Status">The status of the order.</param>
    public record CurrentOrderResult(Guid Id, int Sum, OrderStatus Status);
}