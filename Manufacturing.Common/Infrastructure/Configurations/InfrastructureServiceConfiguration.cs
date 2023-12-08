using Manufacturing.Common.Common.Extensions;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Manufacturing.Common.Infrastructure.Configurations
{
    public static class InfrastructureServiceConfiguration
    {
        public static IServiceCollection AddMassTransitBus(
            this IServiceCollection services,
            IConfiguration configuration,
            Type[] consumers)
        {
            return services.AddMassTransit(busConfigurator =>
            {
                consumers.ForEach(consumer => busConfigurator.AddConsumer(consumer));

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
        }
    }
}
