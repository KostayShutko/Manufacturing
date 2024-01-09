using Manufacturing.Common.Application.Configurations;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using WorkflowOrchestrator.Application.Workflows;
using WorkflowOrchestrator.Domain.Entities;
using WorkflowOrchestrator.Infrastructure.Database;

namespace WorkflowOrchestrator.Application;

public static class ApplicationServicesRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        var executingAssembly = Assembly.GetExecutingAssembly();

        services.AddAutoMapper(executingAssembly);
        services.AddMediatRConfiguration(executingAssembly);

        return services;
    }

    public static void StateMachineConfigurator(IBusRegistrationConfigurator busConfigurator)
    {
        busConfigurator
            .AddSagaStateMachine<ProductProductionWorkflow, ProductProductionWorkflowState>()
            .EntityFrameworkRepository(r =>
            {
                r.ExistingDbContext<WorkflowsContext>();
                r.UseSqlServer();
            });
    }
}