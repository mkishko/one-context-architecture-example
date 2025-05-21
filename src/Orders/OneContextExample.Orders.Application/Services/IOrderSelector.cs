using OneContextExample.Orders.Domain;

namespace OneContextExample.Orders.Application.Services;

public interface IOrderSelector
{
    Task<Order?> GetOrder(Guid id, CancellationToken cancellationToken = default);
}