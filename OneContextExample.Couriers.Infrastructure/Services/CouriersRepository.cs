using OneContextExample.Couriers.Domain;
using OneContextExample.Infrastructure.DataAccess;
using OneContextExample.Infrastructure.Services;
using Db = OneContextExample.Infrastructure.DataAccess.Couriers;

namespace OneContextExample.Couriers.Infrastructure.Services;

internal class CouriersRepository(
    DataContext context,
    IDomainEventsDispatcher dispatcher) :
    EntityRepository<Courier, Db.Courier>(context, dispatcher),
    ICouriersRepository;