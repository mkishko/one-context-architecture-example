namespace OneContextExample.Couriers.Application.IntergationEvents;

public record CourierTookOrder(Guid EventId, Guid CourierId, Guid OrderId, int Version);