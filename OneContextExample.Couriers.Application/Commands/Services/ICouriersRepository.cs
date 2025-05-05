using OneContextExample.Couriers.Domain;

namespace OneContextExample.Couriers.Application.Commands.Services;

public interface ICouriersRepository
{
    Task<Courier?> Get(Guid id, CancellationToken cancellationToken = default);
    
    Task Save(Courier courier, CancellationToken cancellationToken = default);
}