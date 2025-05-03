using Mediator;
using OneContextExample.Infrastructure.Common.Services;
using OneContextExample.Infrastructure.Data;
using OneContextExample.Orders.Application.Commands.Services;
using OneContextExample.Orders.Domain;
using Db = OneContextExample.Infrastructure.Data.Orders;

namespace OneContextExample.Infrastructure.Orders.Services;

internal class OrdersPreserver(
    DataContext context,
    IPublisher publisher) :
    EntityPreserver<Order, Db.Order>(context, publisher),
    IOrdersPreserver;