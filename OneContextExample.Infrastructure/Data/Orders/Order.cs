using OneContextExample.Core.Enums;

using Domain = OneContextExample.Orders.Domain;

namespace OneContextExample.Infrastructure.Data.Orders;

internal class Order : IEntityData<Order, Domain.Order>
{
    public Guid Id { get; set; }
    
    public int Sum { get; set; }
    
    public OrderStatus Status { get; set; }

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