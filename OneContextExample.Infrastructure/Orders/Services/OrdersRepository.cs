using OneContextExample.Infrastructure.Common.Services;
using OneContextExample.Infrastructure.Data;
using OneContextExample.Orders.Domain;
using Db = OneContextExample.Infrastructure.Data.Orders;

namespace OneContextExample.Infrastructure.Orders.Services;

internal class OrdersRepository(
    DataContext context,
    IDomainEventsDispatcher dispatcher) :
    EntityRepository<Order, Db.Order>(context, dispatcher),
    IOrdersRepository;