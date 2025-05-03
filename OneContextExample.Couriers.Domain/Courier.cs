using OneContextExample.Core;
using OneContextExample.Couriers.Domain.Events;

namespace OneContextExample.Couriers.Domain;

public class Courier : Entity
{
    public Courier(string name)
        : this(Guid.NewGuid(), name)
    {
    }

    internal Courier(Guid id, string name, Guid? currentOrderId = null)
    {
        Id = id != Guid.Empty ? id : throw new ArgumentException(nameof(id));
        Name = !string.IsNullOrWhiteSpace(name) ? name : throw new ArgumentException(nameof(name));
        CurrentOrderId = currentOrderId is null || currentOrderId != Guid.Empty
            ? currentOrderId
            : throw new ArgumentException(nameof(currentOrderId));
    }

    public override Guid Id { get; }

    public string Name { get; }

    public Guid? CurrentOrderId { get; private set; }

    public bool IsBusy => CurrentOrderId is not null;

    public void TakeOrder(Guid orderId)
    {
        if (orderId == Guid.Empty)
        {
            throw new ArgumentException(nameof(orderId));
        }

        if (CurrentOrderId is not null)
        {
            throw new InvalidOperationException("Can't take order more than once.");
        }
        
        CurrentOrderId = orderId;
        AddEvent(new OrderTakenEvent(orderId));
    }
}