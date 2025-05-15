using System.Net.Mime;
using Dodo.Kafka.Outbox.MySql;
using Microsoft.EntityFrameworkCore;
using OneContextExample.Core;
using OneContextExample.Couriers.Application.Events;
using OneContextExample.Couriers.Application.Services;
using OneContextExample.Couriers.Domain;
using OneContextExample.Infrastructure.Common.Services;
using OneContextExample.Infrastructure.Couriers.Adapters;
using OneContextExample.Infrastructure.Couriers.Services;
using OneContextExample.Infrastructure.Data;
using OneContextExample.Infrastructure.Orders;
using OneContextExample.Infrastructure.Orders.Services;
using OneContextExample.Orders.Application.Services;
using OneContextExample.Orders.Domain;

namespace OneContextExample.Api.Extensions;

internal static class ServiceCollectionExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Db");
        services.AddDbContext<DataContext>(options =>
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
        
        services.AddMySqlKafkaOutboxEventRepository(repConfigurator =>
        {
            repConfigurator.AddTable("events_outbox", tableConfigurator =>
            {
                tableConfigurator.AddEventMapping<CourierTookOrder>(
                    e => e.EventId.ToByteArray(),
                    e => e.EventId.ToByteArray(),
                    e => e.Version,
                    "courier-orders");
            });
        });
        
        services.AddMediator(options =>
        {
            options.ServiceLifetime = ServiceLifetime.Scoped;
        });

        services.AddScoped<IIntegrationEventsPublisher, IntegrationEventsPublisher>();

        services.AddScoped<ICouriersSelector, CouriersSelector>();
        services.AddScoped<ICouriersRepository, CouriersRepository>();
        services.AddScoped<IOrdersAccessor, OrdersAccessorAdapter>();

        services.AddScoped<IOrdersSelector, OrdersSelector>();
        services.AddScoped<IOrdersRepository, OrdersRepository>();
        
        return services;
    }
}