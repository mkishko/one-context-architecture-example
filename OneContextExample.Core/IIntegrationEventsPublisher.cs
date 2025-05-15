namespace OneContextExample.Core;

public interface IIntegrationEventsPublisher
{
    Task Publish<T>(T integrationEvent, CancellationToken cancellationToken = default)
        where T : notnull;
}