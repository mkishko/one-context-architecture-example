using Mediator;

namespace OneContextExample.Couriers.Application.Commands;

public record TakeOrderCommand(Guid CourierId, Guid OrderId) : ICommand<bool>;