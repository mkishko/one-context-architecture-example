namespace OneContextExample.Orders.Domain;

public interface IOrderRepository
{
    Task<Order?> Get(Guid id, CancellationToken cancellationToken = default);
    
    Task Save(Order order, CancellationToken cancellationToken = default);
}