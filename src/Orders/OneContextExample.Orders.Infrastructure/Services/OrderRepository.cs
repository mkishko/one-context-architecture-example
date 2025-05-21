using OneContextExample.Infrastructure.DataAccess;
using OneContextExample.Infrastructure.Services;
using OneContextExample.Orders.Domain;
using Db = OneContextExample.Infrastructure.DataAccess.Orders;

namespace OneContextExample.Orders.Infrastructure.Services;

internal class OrderRepository(
    DataContext context,
    IDomainEventDispatcher dispatcher) :
    EntityRepository<Order, Db.Order>(context, dispatcher),
    IOrderRepository;