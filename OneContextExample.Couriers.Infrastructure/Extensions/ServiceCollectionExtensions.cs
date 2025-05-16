using Microsoft.Extensions.DependencyInjection;
using OneContextExample.Couriers.Application.Services;
using OneContextExample.Couriers.Domain;
using OneContextExample.Couriers.Infrastructure.Adapters;
using OneContextExample.Couriers.Infrastructure.Services;

namespace OneContextExample.Couriers.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCouriersServices(this IServiceCollection services)
    {
        services.AddScoped<ICouriersSelector, CouriersSelector>();
        services.AddScoped<ICouriersRepository, CouriersRepository>();
        services.AddScoped<IOrdersAccessor, OrdersAccessorAdapter>();
        
        return services;
    }
}