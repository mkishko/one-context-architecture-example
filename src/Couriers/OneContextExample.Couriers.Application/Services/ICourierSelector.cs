using OneContextExample.Couriers.Contracts.Queries;

namespace OneContextExample.Couriers.Application.Services;

public interface ICourierSelector
{
    Task<IReadOnlyCollection<GetCouriersItemViewModel>> GetCouriers(CancellationToken cancellationToken = default);
    
    Task<GetCouriersItemViewModel?> GetCourier(Guid id, CancellationToken cancellationToken = default);
}