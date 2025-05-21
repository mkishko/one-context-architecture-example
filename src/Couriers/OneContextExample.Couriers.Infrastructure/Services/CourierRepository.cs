using OneContextExample.Couriers.Domain;
using OneContextExample.Infrastructure.DataAccess;
using OneContextExample.Infrastructure.Services;
using Db = OneContextExample.Infrastructure.DataAccess.Couriers;

namespace OneContextExample.Couriers.Infrastructure.Services;

internal class CourierRepository(
    DataContext context,
    IDomainEventDispatcher dispatcher) :
    EntityRepository<Courier, Db.Courier>(context, dispatcher),
    ICourierRepository;