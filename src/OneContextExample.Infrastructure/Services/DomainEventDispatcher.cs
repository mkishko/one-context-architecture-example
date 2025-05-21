using Mediator;
using OneContextExample.Core;

namespace OneContextExample.Infrastructure.Services;

internal class DomainEventDispatcher(IPublisher publisher) : IDomainEventDispatcher
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