using Microsoft.EntityFrameworkCore;
using OneContextExample.Couriers.Application.Commands.Services;
using OneContextExample.Couriers.Application.Queries.Services;
using OneContextExample.Infrastructure.Couriers.Adapters;
using OneContextExample.Infrastructure.Couriers.Services;
using OneContextExample.Infrastructure.Data;
using OneContextExample.Infrastructure.Orders;
using OneContextExample.Infrastructure.Orders.Services;
using OneContextExample.Orders.Application.Commands.Services;
using IOrdersExtractor = OneContextExample.Orders.Application.Queries.Services.IOrdersExtractor;

namespace OneContextExample.Api.Extensions;

internal static class ServiceCollectionExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<DataContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("Db")));
        
        services.AddMediator(options =>
        {
            options.ServiceLifetime = ServiceLifetime.Scoped;
        });

        services.AddScoped<ICouriersExtractor, CouriersExtractor>();
        services.AddScoped<ICouriersPreserver, CouriersPreserver>();
        services.AddScoped<IOrdersAccessor, OrdersAccessorAdapter>();

        services.AddScoped<IOrdersExtractor, OrdersExtractor>();
        services.AddScoped<IOrdersPreserver, OrdersPreserver>();
        
        return services;
    }
}