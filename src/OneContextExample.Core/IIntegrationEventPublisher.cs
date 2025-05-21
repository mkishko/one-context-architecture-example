namespace OneContextExample.Core;

public interface IIntegrationEventPublisher
{
    Task Publish<T>(T integrationEvent, CancellationToken cancellationToken = default)
        where T : notnull;
}