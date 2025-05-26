using OneContextExample.Couriers.Contracts.Queries;

namespace OneContextExample.Couriers.Application.Services;

public interface ICourierSelector
{
    Task<IReadOnlyCollection<GetCouriersItemResult>> GetCouriers(CancellationToken cancellationToken = default);
    
    Task<GetCourierResult?> GetCourier(Guid id, CancellationToken cancellationToken = default);
}