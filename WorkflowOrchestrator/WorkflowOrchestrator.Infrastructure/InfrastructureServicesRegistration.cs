using Manufacturing.Common.Infrastructure.Configurations;
using Manufacturing.Common.Infrastructure.Database;
using Manufacturing.Common.Infrastructure.EventBus;
using Manufacturing.Common.Infrastructure.Providers;
using MassTransit;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WorkflowOrchestrator.Infrastructure.Database;

namespace WorkflowOrchestrator.Infrastructure;

public static class InfrastructureServicesRegistration
{
    public static IServiceCollection AddInfrastructureServices(
            this IServiceCollection services,
            IConfiguration configuration,
            Action<IBusRegistrationConfigurator> stateMachineConfigurator)
    {
        services.AddDbContext<WorkflowsContext>(options => options.UseSqlServer(configuration.GetConnectionString("DatabaseConnectionString")));
        services.AddTransient<IEventPublisher, EventPublisher>();
        services.AddScoped<IDateTimeProvider, DateTimeProvider>();

        services.AddMassTransit(busConfigurator =>
        {
            stateMachineConfigurator(busConfigurator);

            busConfigurator.AddMassTransitRabbitMq(configuration);
        });

        return services;
    }

    public static IApplicationBuilder ApplyMigrations(this IApplicationBuilder app)
    {
        app.ApplyMigrations<WorkflowsContext>();

        return app;
    }
}
