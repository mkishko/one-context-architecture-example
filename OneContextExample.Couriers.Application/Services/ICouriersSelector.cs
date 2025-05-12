using OneContextExample.Couriers.Application.Queries.Models;

namespace OneContextExample.Couriers.Application.Services;

public interface ICouriersSelector
{
    Task<IReadOnlyCollection<GetCourierResponse>> GetCouriers(CancellationToken cancellationToken = default);
    
    Task<GetCourierResponse?> GetCourier(Guid id, CancellationToken cancellationToken = default);
}