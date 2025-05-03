using Mediator;

namespace OneContextExample.Core;

public interface IDomainEventsProvider
{
    IReadOnlyList<INotification> ExtractAll();
}