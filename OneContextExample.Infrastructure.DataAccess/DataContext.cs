using Microsoft.EntityFrameworkCore;
using OneContextExample.Infrastructure.DataAccess.Couriers;
using OneContextExample.Infrastructure.DataAccess.Couriers.Configurations;
using OneContextExample.Infrastructure.DataAccess.Orders;
using OneContextExample.Infrastructure.DataAccess.Orders.Configurations;
using OneContextExample.Infrastructure.DataAccess.Outbox.Configurations;

namespace OneContextExample.Infrastructure.DataAccess;

public class DataContext(DbContextOptions<DataContext> options)
    : DbContext(options)
{
    public DbSet<Order> Orders { get; set; }
    
    public DbSet<Courier> Couriers { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CourierConfiguration());
        modelBuilder.ApplyConfiguration(new OrderConfiguration());
        modelBuilder.ApplyConfiguration(new KafkaMessageConfiguration());
    }
}