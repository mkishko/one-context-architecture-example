using OneContextExample.Core;

namespace OneContextExample.Couriers.Application.Commands;

public record TakeOrderCommand(Guid CourierId, Guid OrderId) : ITransactionalCommand<bool>;