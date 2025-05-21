using OneContextExample.Core;

namespace OneContextExample.Infrastructure.Services;

public interface IDomainEventDispatcher
{
    Task Dispatch(IDomainEventsProvider domainEventsProvider, CancellationToken cancellationToken = default);
}