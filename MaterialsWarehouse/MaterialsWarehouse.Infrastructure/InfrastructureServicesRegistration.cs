using Manufacturing.Common.Infrastructure.Configurations;
using Manufacturing.Common.Infrastructure.EventBus;
using Manufacturing.Common.Infrastructure.Providers;
using Manufacturing.Common.Infrastructure.Repository;
using Manufacturing.Common.Infrastructure.Database;
using MaterialsWarehouse.Infrastructure.Database;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MaterialsWarehouse.Infrastructure;

public static class InfrastructureServicesRegistration
{
    public static IServiceCollection AddInfrastructureServices(
        this IServiceCollection services, 
        IConfiguration configuration, 
        Type[] consumers)
    {
        services.AddMassTransitBus(configuration, consumers);
        services.AddTransient<IEventPublisher, EventPublisher>();
        services.AddDbContext<MaterialsContext>(options => options.UseSqlServer(configuration.GetConnectionString("DatabaseConnectionString")));
        services.AddTransient<IUnitOfWork>(serviceProvider => new UnitOfWork(serviceProvider.GetService<MaterialsContext>()));
        services.AddScoped<IDateTimeProvider, DateTimeProvider>();

        return services;
    }

    public static IApplicationBuilder ApplyMigrations(this IApplicationBuilder app)
    {
        app.ApplyMigrations<MaterialsContext>();

        return app;
    }
}
