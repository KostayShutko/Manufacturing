using Manufacturing.Common.Infrastructure.Configurations;
using Manufacturing.Common.Infrastructure.EventBus;
using Manufacturing.Common.Infrastructure.Providers;
using Manufacturing.Common.Infrastructure.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using ProcessingMachines.Infrastructure.Database;
using Microsoft.AspNetCore.Builder;
using Manufacturing.Common.Infrastructure.Database;

namespace ProcessingMachines.Infrastructure;

public static class InfrastructureServicesRegistration
{
    public static IServiceCollection AddInfrastructureServices(
        this IServiceCollection services,
        IConfiguration configuration,
        Type[] consumers)
    {
        services.AddMassTransitBus(configuration, consumers);
        services.AddTransient<IEventPublisher, EventPublisher>();
        services.AddDbContext<ProcessesContext>(options => options.UseSqlServer(configuration.GetConnectionString("DatabaseConnectionString")));
        services.AddTransient<IUnitOfWork>(serviceProvider => new UnitOfWork(serviceProvider.GetService<ProcessesContext>()));
        services.AddScoped<IDateTimeProvider, DateTimeProvider>();

        return services;
    }

    public static IApplicationBuilder ApplyMigrations(this IApplicationBuilder app)
    {
        app.ApplyMigrations<ProcessesContext>();

        return app;
    }
}
