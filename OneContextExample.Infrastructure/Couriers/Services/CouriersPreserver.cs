using Mediator;
using OneContextExample.Couriers.Application.Commands.Services;
using OneContextExample.Couriers.Domain;
using OneContextExample.Infrastructure.Common.Services;
using OneContextExample.Infrastructure.Data;

using Db = OneContextExample.Infrastructure.Data.Couriers;

namespace OneContextExample.Infrastructure.Couriers.Services;

internal class CouriersPreserver(
    DataContext context,
    IPublisher publisher) :
    EntityPreserver<Courier, Db.Courier>(context, publisher),
    ICouriersPreserver;