using OneContextExample.Orders.Domain;

namespace OneContextExample.Orders.Application.Commands.Services;

public interface IOrdersPreserver
{
    Task<Order?> Get(Guid id, CancellationToken cancellationToken = default);
    
    Task Save(Order order, CancellationToken cancellationToken = default);
}