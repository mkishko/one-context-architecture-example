using OneContextExample.Core;

namespace OneContextExample.Infrastructure.Services;

public interface IDomainEventsDispatcher
{
    Task Dispatch(IDomainEventsProvider domainEventsProvider, CancellationToken cancellationToken = default);
}