using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Manufacturing.Common.Infrastructure.Database;

public static class MigrationExtensions
{
    public static IApplicationBuilder ApplyMigrations<TDbContext>(this IApplicationBuilder app)
        where TDbContext : DbContext
    {
        var serviceScopeFactory = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>();
        using var applyMigrationsScope = serviceScopeFactory.CreateScope();
        var dbContext = applyMigrationsScope.ServiceProvider.GetService<TDbContext>();
        dbContext?.Database.Migrate();
        return app;
    }
}
