using Manufacturing.Common.API.Middlewares;
using WorkflowOrchestrator.Application;
using WorkflowOrchestrator.Infrastructure;

namespace WorkflowOrchestrator.API;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        services.AddApplicationServices();
        services.AddInfrastructureServices(Configuration, ApplicationServicesRegistration.StateMachineConfigurator);

        services.AddScoped<ExceptionHandlingMiddleware>();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseSwagger();
        app.UseSwaggerUI();

        app.UseMiddleware<ExceptionHandlingMiddleware>();

        app.UseRouting();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });

        app.ApplyMigrations();
    }
}