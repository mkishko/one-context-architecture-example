using OneContextExample.Orders.Domain;

namespace OneContextExample.Orders.Application.Services;

public interface IOrdersSelector
{
    Task<Order?> GetOrder(Guid id, CancellationToken cancellationToken = default);
}