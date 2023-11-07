﻿using Manufacturing.Common.Infrastructure.Providers;
using Manufacturing.Common.Infrastructure.Repository;
using MaterialsWarehouse.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MaterialsWarehouse.Infrastructure
{
    public static class InfrastructureServicesRegistration
    {
        public static IServiceCollection ConfigureInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MaterialsContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            services.AddTransient<IUnitOfWork>(serviceProvider => new UnitOfWork(serviceProvider.GetService<MaterialsContext>()));
            services.AddScoped<IDateTimeProvider, DateTimeProvider>();

            return services;
        }
    }
}
