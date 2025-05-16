using OneContextExample.Core;

namespace OneContextExample.Orders.Application.Commands;

public record TakeOrderCommand(Guid OrderId) : ITransactionalCommand;