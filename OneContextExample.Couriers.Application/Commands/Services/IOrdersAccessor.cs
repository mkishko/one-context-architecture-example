namespace OneContextExample.Couriers.Application.Commands.Services;

public interface IOrdersAccessor
{
    Task<bool> CanBeTaken(Guid id, CancellationToken cancellationToken = default);
    
    Task TakeOrder(Guid id, CancellationToken cancellationToken = default);
}