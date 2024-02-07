using Manufacturing.Common.Infrastructure.Configurations;
using Manufacturing.Common.Infrastructure.Database;
using Manufacturing.Common.Infrastructure.EventBus;
using Manufacturing.Common.Infrastructure.Providers;
using Manufacturing.Common.Infrastructure.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Transportations.Infrastructure.Database;

namespace Transportations.Infrastructure;

public static class InfrastructureServicesRegistration
{
    public static IServiceCollection AddInfrastructureServices(
            this IServiceCollection services,
            IConfiguration configuration,
            Type[] consumers)
    {
        services.AddMassTransitBus(configuration, consumers);
        services.AddTransient<IEventPublisher, EventPublisher>();
        services.AddDbContext<TransportationsContext>(options => options.UseSqlServer(configuration.GetConnectionString("DatabaseConnectionString")));
        services.AddTransient<IUnitOfWork>(serviceProvider => new UnitOfWork(serviceProvider.GetService<TransportationsContext>()));
        services.AddScoped<IDateTimeProvider, DateTimeProvider>();

        return services;
    }

    public static IApplicationBuilder ApplyMigrations(this IApplicationBuilder app)
    {
        app.ApplyMigrations<TransportationsContext>();

        return app;
    }
}
