using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OneContextExample.Infrastructure.Data.Outbox.Configurations;

internal class KafkaMessageConfiguration : IEntityTypeConfiguration<KafkaMessage>
{
    public void Configure(EntityTypeBuilder<KafkaMessage> builder)
    {
        builder.ToTable("events_outbox");
        
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Key).HasMaxLength(16);
        builder.Property(e => e.EntityId).HasMaxLength(16);
        builder.Property(e => e.Topic).HasMaxLength(100);
        builder.Property(e => e.Headers).HasMaxLength(255);
        builder.HasIndex(e => new { e.EntityId, e.Version, e.Topic }).IsUnique();
    }
}