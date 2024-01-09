using Manufacturing.Common.Common.Extensions;
using Manufacturing.Common.Infrastructure.Configurations;
using Manufacturing.Common.Infrastructure.EventBus;
using Manufacturing.Common.Infrastructure.Providers;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace WorkflowOrchestrator.Infrastructure;

public static class InfrastructureServicesRegistration
{
    public static IServiceCollection AddInfrastructureServices(
            this IServiceCollection services,
            IConfiguration configuration,
            Action<IBusRegistrationConfigurator> stateMachineConfigurator)
    {
        services.AddMassTransit(busConfigurator =>
        {
            stateMachineConfigurator(busConfigurator);

            busConfigurator.UsingRabbitMq((context, busFactoryConfigurator) =>
            {
                var rabbitMqConfiguration = configuration.GetConfigurationModel<RabbitMqConfiguration>(nameof(RabbitMqConfiguration));
                busFactoryConfigurator.Host(rabbitMqConfiguration.HostName, rabbitMqConfiguration.Port, "/", hostConfigurator =>
                {
                    hostConfigurator.Username(rabbitMqConfiguration.UserName);
                    hostConfigurator.Password(rabbitMqConfiguration.Password);
                });
                busFactoryConfigurator.ConfigureEndpoints(context);
            });
        });
        services.AddTransient<IEventPublisher, EventPublisher>();
        //services.AddDbContext<TransportationsContext>(options => options.UseSqlServer(configuration.GetConnectionString("DatabaseConnectionString")));
        //services.AddTransient<IUnitOfWork>(serviceProvider => new UnitOfWork(serviceProvider.GetService<TransportationsContext>()));
        services.AddScoped<IDateTimeProvider, DateTimeProvider>();

        return services;
    }
}
