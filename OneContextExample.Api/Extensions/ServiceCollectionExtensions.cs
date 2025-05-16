using OneContextExample.Couriers.Infrastructure.Extensions;
using OneContextExample.Infrastructure.Extensions;
using OneContextExample.Orders.Infrastructure.Extensions;

namespace OneContextExample.Api.Extensions;

internal static class ServiceCollectionExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddInfrastructureServices(configuration)
            .AddCouriersServices()
            .AddOrdersServices();
        
        return services;
    }
}