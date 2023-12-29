using Manufacturing.Common.Infrastructure.Configurations;
using Manufacturing.Common.Infrastructure.EventBus;
using Manufacturing.Common.Infrastructure.Providers;
using Manufacturing.Common.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProductsWarehouse.Infrastructure.Database;

namespace ProductsWarehouse.Infrastructure;

public static class InfrastructureServicesRegistration
{
    public static IServiceCollection AddInfrastructureServices(
            this IServiceCollection services,
            IConfiguration configuration,
            Type[] consumers)
    {
        services.AddMassTransitBus(configuration, consumers);
        services.AddTransient<IEventPublisher, EventPublisher>();
        services.AddDbContext<ProductsContext>(options => options.UseSqlServer(configuration.GetConnectionString("DatabaseConnectionString")));
        services.AddTransient<IUnitOfWork>(serviceProvider => new UnitOfWork(serviceProvider.GetService<ProductsContext>()));
        services.AddScoped<IDateTimeProvider, DateTimeProvider>();

        return services;
    }
}