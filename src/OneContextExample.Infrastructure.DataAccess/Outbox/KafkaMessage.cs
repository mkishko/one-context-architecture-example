namespace OneContextExample.Infrastructure.DataAccess.Outbox;

public class KafkaMessage
{
    public long Id { get; init; }

    public byte[] Key { get; init; }

    public byte[] EntityId { get; init; }

    public int Version { get; init; }

    public string Topic { get; init; }

    public byte[] Content { get; init; }

    public byte[] Headers { get; init; }

    public DateTime CreatedAtUtc { get; init; }
}