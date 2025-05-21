namespace OneContextExample.Couriers.Application.Services;

public interface IOrderAccessor
{
    Task<bool> CanBeTaken(Guid id, CancellationToken cancellationToken = default);
    
    Task TakeOrder(Guid id, CancellationToken cancellationToken = default);
}