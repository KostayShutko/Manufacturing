﻿using FluentValidation;
using Manufacturing.Common.Application.Behaviours;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ProcessingMachines.Application.Consumers;
using System.Reflection;

namespace ProcessingMachines.Application;

public static class ApplicationServicesRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        var executingAssembly = Assembly.GetExecutingAssembly();

        services.AddAutoMapper(executingAssembly);
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(executingAssembly));

        services.AddValidatorsFromAssembly(executingAssembly, includeInternalTypes: true);

        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));

        return services;
    }

    public static Type[] GetConsumers() => 
        new Type[] 
        { 
            typeof(MaterialTransportedConsumer), 
            typeof(ProcessCreatedConsumer) 
        };
}