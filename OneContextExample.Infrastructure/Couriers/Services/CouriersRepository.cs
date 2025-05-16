using OneContextExample.Couriers.Domain;
using OneContextExample.Infrastructure.Common.Services;
using OneContextExample.Infrastructure.Data;

using Db = OneContextExample.Infrastructure.Data.Couriers;

namespace OneContextExample.Infrastructure.Couriers.Services;

internal class CouriersRepository(
    DataContext context,
    IDomainEventsDispatcher dispatcher) :
    EntityRepository<Courier, Db.Courier>(context, dispatcher),
    ICouriersRepository;