using Mediator;
using OneContextExample.Infrastructure.Common.Services;
using OneContextExample.Infrastructure.Data;
using OneContextExample.Orders.Domain;
using Db = OneContextExample.Infrastructure.Data.Orders;

namespace OneContextExample.Infrastructure.Orders.Services;

internal class OrdersRepository(
    DataContext context,
    IPublisher publisher) :
    EntityRepository<Order, Db.Order>(context, publisher),
    IOrdersRepository;