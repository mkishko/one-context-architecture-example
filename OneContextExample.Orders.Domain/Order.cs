using OneContextExample.Core;
using OneContextExample.Core.Enums;

namespace OneContextExample.Orders.Domain;

public class Order : Entity
{
    public Order(int sum)
        : this(Guid.NewGuid(), sum, OrderStatus.Created)
    {
    }
    
    internal Order(Guid id, int sum, OrderStatus status)
    {
        Id = id != Guid.Empty ? id : throw new ArgumentException(nameof(id));
        Sum = sum > 0 ? sum : throw new ArgumentException(nameof(sum));
        Status = Enum.IsDefined(status) ? status : throw new ArgumentException(nameof(status));
    }
    
    public override Guid Id { get; }
    
    public int Sum { get; }
    
    public OrderStatus Status { get; private set; }
    
    public bool CanBeTaken => Status == OrderStatus.Created;

    public void TakeOrder()
    {
        if (Status != OrderStatus.Created)
        {
            throw new InvalidOperationException("Order has already been taken");
        }

        Status = OrderStatus.InProgress;
    }
}