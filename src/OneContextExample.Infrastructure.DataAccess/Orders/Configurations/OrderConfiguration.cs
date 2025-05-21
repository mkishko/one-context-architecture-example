using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OneContextExample.Infrastructure.DataAccess.Orders.Configurations;

internal class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.ToTable("orders");

        builder.HasKey(o => o.Id);
        builder.Property(o => o.Sum)
            .IsRequired();
        builder.Property(o => o.Status)
            .IsRequired()
            .HasConversion<string>();
    }
}