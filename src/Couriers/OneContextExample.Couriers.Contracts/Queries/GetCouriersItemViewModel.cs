using OneContextExample.Core.Enums;

namespace OneContextExample.Couriers.Contracts.Queries;

public record GetCouriersItemViewModel(Guid Id, string Name, GetCouriersItemViewModel.CurrentOrderDto? CurrentOrder)
{
    public record CurrentOrderDto(Guid Id, int Sum, OrderStatus Status);
}