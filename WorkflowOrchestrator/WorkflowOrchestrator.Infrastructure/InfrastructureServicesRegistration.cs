using Manufacturing.Common.Infrastructure.Configurations;
using Manufacturing.Common.Infrastructure.EventBus;
using Manufacturing.Common.Infrastructure.Providers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace WorkflowOrchestrator.Infrastructure;

public static class InfrastructureServicesRegistration
{
    public static IServiceCollection AddInfrastructureServices(
            this IServiceCollection services,
            IConfiguration configuration,
            Type[] consumers)
    {
        services.AddMassTransitBus(configuration, consumers);
        services.AddTransient<IEventPublisher, EventPublisher>();
        //services.AddDbContext<TransportationsContext>(options => options.UseSqlServer(configuration.GetConnectionString("DatabaseConnectionString")));
        //services.AddTransient<IUnitOfWork>(serviceProvider => new UnitOfWork(serviceProvider.GetService<TransportationsContext>()));
        services.AddScoped<IDateTimeProvider, DateTimeProvider>();

        return services;
    }
}
