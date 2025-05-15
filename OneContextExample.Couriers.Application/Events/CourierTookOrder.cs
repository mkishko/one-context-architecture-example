namespace OneContextExample.Couriers.Application.Events;

public record CourierTookOrder(Guid EventId, Guid CourierId, Guid OrderId, int Version);