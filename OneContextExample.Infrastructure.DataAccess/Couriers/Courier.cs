using OneContextExample.Infrastructure.DataAccess.Orders;
using Domain = OneContextExample.Couriers.Domain;

namespace OneContextExample.Infrastructure.DataAccess.Couriers;

public class Courier : IEntityData<Courier, Domain.Courier>
{
    public Guid Id { get; set; }

    public string Name { get; set; }
    
    public Guid? CurrentOrderId { get; set; }
    
    public Order? CurrentOrder { get; set; }

    public Domain.Courier ToEntity()
    {
        return new Domain.Courier(Id, Name, CurrentOrderId);
    }
    
    public static Courier FromEntity(Domain.Courier entity)
    {
        return new Courier
        {
            Id = entity.Id,
            Name = entity.Name,
            CurrentOrderId = entity.CurrentOrderId,
        };
    }
}