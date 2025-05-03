using Mediator;

namespace OneContextExample.Orders.Application.Commands;

public record TakeOrderCommand(Guid OrderId) : ICommand;