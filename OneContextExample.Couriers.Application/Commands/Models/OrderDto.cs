using OneContextExample.Core.Enums;

namespace OneContextExample.Couriers.Application.Commands.Models;

public record OrderDto(Guid Id, OrderStatus Status);