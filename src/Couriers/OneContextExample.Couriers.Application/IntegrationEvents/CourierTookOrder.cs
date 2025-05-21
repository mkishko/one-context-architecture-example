namespace OneContextExample.Couriers.Application.IntegrationEvents;

public record CourierTookOrder(Guid EventId, Guid CourierId, Guid OrderId, int Version);