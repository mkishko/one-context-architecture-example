using OneContextExample.Core;

namespace OneContextExample.Couriers.Contracts.Commands;

public record TakeOrderCommand(Guid CourierId, Guid OrderId) : ITransactionalCommand<bool>;