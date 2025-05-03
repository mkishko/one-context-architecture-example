using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OneContextExample.Infrastructure.Data.Couriers.Configurations;

internal class CourierConfiguration : IEntityTypeConfiguration<Courier>
{
    public void Configure(EntityTypeBuilder<Courier> builder)
    {
        builder.ToTable("couriers");

        builder.HasKey(c => c.Id);
        builder.Property(c => c.Name)
            .IsRequired();
        builder.HasOne(c => c.CurrentOrder)
            .WithMany()
            .HasForeignKey(c => c.CurrentOrderId);
    }
}