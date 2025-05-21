using OneContextExample.Core;

namespace OneContextExample.Orders.Contracts.Commands;

public record TakeOrderCommand(Guid OrderId) : ITransactionalCommand;