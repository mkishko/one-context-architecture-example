using OneContextExample.Infrastructure.DataAccess;
using OneContextExample.Infrastructure.Services;
using OneContextExample.Orders.Domain;
using Db = OneContextExample.Infrastructure.DataAccess.Orders;

namespace OneContextExample.Orders.Infrastructure.Services;

internal class OrdersRepository(
    DataContext context,
    IDomainEventsDispatcher dispatcher) :
    EntityRepository<Order, Db.Order>(context, dispatcher),
    IOrdersRepository;