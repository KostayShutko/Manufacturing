using Manufacturing.Common.Infrastructure.Interceptors;
using Manufacturing.Common.Infrastructure.Providers;
using Microsoft.EntityFrameworkCore;
using ProcessingMachines.Domain.Entities;

namespace ProcessingMachines.Infrastructure.Database;

public class ProcessesContext : DbContext
{
    private readonly IDateTimeProvider dateTimeProvider;

    public ProcessesContext(IDateTimeProvider dateTimeProvider, DbContextOptions<ProcessesContext> options)
        : base(options)
    {
        this.dateTimeProvider = dateTimeProvider;
    }

    public DbSet<Process>? Processes { get; set; }

    public DbSet<Product>? Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ProcessEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new ProductEntityTypeConfiguration());

        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(new AuditableEntitySaveChangesInterceptor(dateTimeProvider));
    }
}
