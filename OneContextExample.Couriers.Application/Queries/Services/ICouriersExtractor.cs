using OneContextExample.Couriers.Application.Queries.Models;

namespace OneContextExample.Couriers.Application.Queries.Services;

public interface ICouriersExtractor
{
    Task<IReadOnlyCollection<GetCourierResponse>> GetCouriers(CancellationToken cancellationToken = default);
    
    Task<GetCourierResponse?> GetCourier(Guid id, CancellationToken cancellationToken = default);
}