using OneContextExample.Core.Enums;

namespace OneContextExample.Couriers.Application.Queries.Models;

public record GetCourierResponse(Guid Id, string Name, GetCourierResponse.CurrentOrderDto? CurrentOrder)
{
    public record CurrentOrderDto(Guid Id, int Sum, OrderStatus Status);
}