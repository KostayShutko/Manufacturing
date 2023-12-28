using Microsoft.Extensions.DependencyInjection;
using ProcessingMachines.Domain.Entities.ProcessingMachines;
using ProcessingMachines.Domain.Entities.ProcessingOperations;

namespace ProcessingMachines.Domain;

public static class DomainServicesRegistration
{
    public static IServiceCollection AddDomainServices(this IServiceCollection services)
    {
        services.AddScoped<IProcessingMachinesScheduler, ProcessingMachinesScheduler>();
        services.AddScoped<IProcessingOperationsPlanner, ProcessingOperationsPlanner>();

        return services;
    }
}
