using Dodo.Kafka.Outbox.MySql;
using Mediator;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OneContextExample.Core;
using OneContextExample.Couriers.Application.IntergationEvents;
using OneContextExample.Infrastructure.Common.Services;
using OneContextExample.Infrastructure.Data;
using OneContextExample.Infrastructure.PipelineBehaviours;

namespace OneContextExample.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
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
        
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(TransactionalPipelineBehaviour<,>));
        
        services.AddScoped<IIntegrationEventsPublisher, IntegrationEventsPublisher>();
        services.AddScoped<IDomainEventsDispatcher, DomainEventsDispatcher>();

        return services;
    }
}