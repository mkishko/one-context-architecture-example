using Microsoft.Extensions.DependencyInjection;
using OneContextExample.Orders.Application.Services;
using OneContextExample.Orders.Domain;
using OneContextExample.Orders.Infrastructure.Services;

namespace OneContextExample.Orders.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddOrdersServices(this IServiceCollection services)
    {
        services.AddScoped<IOrderSelector, OrderSelector>();
        services.AddScoped<IOrderRepository, OrderRepository>();
        
        return services;
    }
}