using Microsoft.EntityFrameworkCore;
using OneContextExample.Infrastructure.Data.Couriers;
using OneContextExample.Infrastructure.Data.Couriers.Configurations;
using OneContextExample.Infrastructure.Data.Orders;
using OneContextExample.Infrastructure.Data.Orders.Configurations;

namespace OneContextExample.Infrastructure.Data;

internal class DataContext(DbContextOptions<DataContext> options)
    : DbContext(options)
{
    public DbSet<Order> Orders { get; set; }
    
    public DbSet<Courier> Couriers { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CourierConfiguration());
        modelBuilder.ApplyConfiguration(new OrderConfiguration());
    }
}