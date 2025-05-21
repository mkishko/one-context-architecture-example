namespace OneContextExample.Couriers.Domain;

public interface ICourierRepository
{
    Task<Courier?> Get(Guid id, CancellationToken cancellationToken = default);
    
    Task Save(Courier courier, CancellationToken cancellationToken = default);
}