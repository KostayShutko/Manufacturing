using Manufacturing.Common.Application.Configurations;
using MaterialsWarehouse.Application.Consumers;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace MaterialsWarehouse.Application;

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
            typeof(ReserveMaterialConsumer),
            typeof(MaterialTransportedConsumer)
        };
}
