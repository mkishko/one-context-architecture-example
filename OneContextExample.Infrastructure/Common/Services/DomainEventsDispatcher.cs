using Mediator;
using OneContextExample.Core;

namespace OneContextExample.Infrastructure.Common.Services;

internal class DomainEventsDispatcher(IPublisher publisher) : IDomainEventsDispatcher
{
    public async Task Dispatch(IDomainEventsProvider domainEventsProvider, CancellationToken cancellationToken = default)
    {
        var domainEvents = domainEventsProvider.ExtractAll();
        for (var i = 0; i < domainEvents.Count; i++)
        {
            await publisher.Publish(domainEvents[i], cancellationToken);
        }
    }
}