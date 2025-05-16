using OneContextExample.Core;

namespace OneContextExample.Infrastructure.Common.Services;

internal interface IDomainEventsDispatcher
{
    Task Dispatch(IDomainEventsProvider domainEventsProvider, CancellationToken cancellationToken = default);
}