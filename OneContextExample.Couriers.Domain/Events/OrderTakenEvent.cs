using Mediator;

namespace OneContextExample.Couriers.Domain.Events;

public record OrderTakenEvent(Guid OrderId) : INotification;