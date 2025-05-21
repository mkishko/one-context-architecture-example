using OneContextExample.Orders.Contracts.Queries;
using OneContextExample.Orders.Domain;

namespace OneContextExample.Orders.Application.Services;

public interface IOrderSelector
{
    Task<Order?> GetOrderAsEntity(Guid id, CancellationToken cancellationToken = default);
    Task<GetOrderViewModel?> GetOrderAsViewModel(Guid id, CancellationToken cancellationToken = default);
}