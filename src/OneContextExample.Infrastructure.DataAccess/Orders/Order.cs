using OneContextExample.Core.Enums;
using Domain = OneContextExample.Orders.Domain;

namespace OneContextExample.Infrastructure.DataAccess.Orders;

public class Order : IEntityData<Order, Domain.Order>
{
    public Guid Id { get; init; }
    
    public int Sum { get; init; }
    
    public OrderStatus Status { get; init; }

    public static Order FromEntity(Domain.Order entity)
    {
        return new Order
        {
            Id = entity.Id,
            Sum = entity.Sum,
            Status = entity.Status,
        };
    }

    public Domain.Order ToEntity()
    {
        return new Domain.Order(Id, Sum, Status);
    }
}