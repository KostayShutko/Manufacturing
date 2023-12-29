using Manufacturing.Common.Application.Configurations;
using Microsoft.Extensions.DependencyInjection;
using ProductsWarehouse.Application.Consumers;
using System.Reflection;

namespace ProductsWarehouse.Application;

public static class ApplicationServicesRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        var executingAssembly = Assembly.GetExecutingAssembly();

        services.AddAutoMapper(executingAssembly);
        services.AddMediatRConfiguration(executingAssembly);

        return services;
    }

    public static Type[] GetConsumers() => 
        new Type[] 
        { 
            typeof(ReserveProductConsumer), 
            typeof(ProductTransportedConsumer) 
        };
}
