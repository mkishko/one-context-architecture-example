namespace OneContextExample.Orders.Domain;

public interface IOrdersRepository
{
    Task<Order?> Get(Guid id, CancellationToken cancellationToken = default);
    
    Task Save(Order order, CancellationToken cancellationToken = default);
}