using FluentValidation;
using Manufacturing.Common.Application.Behaviours;
using MaterialsWarehouse.Application.Consumers;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace MaterialsWarehouse.Application
{
    public static class ApplicationServicesRegistration
    {
        public static IServiceCollection ConfigureApplicationServices(this IServiceCollection services)
        {
            var executingAssembly = Assembly.GetExecutingAssembly();

            services.AddAutoMapper(executingAssembly);
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(executingAssembly));

            services.AddValidatorsFromAssembly(executingAssembly, includeInternalTypes: true);

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));

            return services;
        }

        public static Type[] GetConsumers() => new Type[] { typeof(ReserveMaterialConsumer) };
    }
}
