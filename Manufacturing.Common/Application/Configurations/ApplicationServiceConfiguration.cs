using FluentValidation;
using Manufacturing.Common.Application.Behaviours;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Manufacturing.Common.Application.Configurations;

public static class ApplicationServiceConfiguration
{
    public static IServiceCollection AddMediatRConfiguration(this IServiceCollection services, Assembly executingAssembly)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(executingAssembly));
        services.AddValidatorsFromAssembly(executingAssembly, includeInternalTypes: true);
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));

        return services;
    }
}
