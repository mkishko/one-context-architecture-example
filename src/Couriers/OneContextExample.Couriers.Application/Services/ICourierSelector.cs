using OneContextExample.Couriers.Contracts.Queries.Models;

namespace OneContextExample.Couriers.Application.Services;

public interface ICourierSelector
{
    Task<IReadOnlyCollection<GetCourierResponse>> GetCouriers(CancellationToken cancellationToken = default);
    
    Task<GetCourierResponse?> GetCourier(Guid id, CancellationToken cancellationToken = default);
}