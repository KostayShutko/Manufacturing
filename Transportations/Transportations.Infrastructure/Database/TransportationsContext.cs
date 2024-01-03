using Manufacturing.Common.Infrastructure.Interceptors;
using Manufacturing.Common.Infrastructure.Providers;
using Microsoft.EntityFrameworkCore;
using Transportations.Domain.Entities;

namespace Transportations.Infrastructure.Database;

public class TransportationsContext : DbContext
{
    private readonly IDateTimeProvider dateTimeProvider;

    public TransportationsContext(IDateTimeProvider dateTimeProvider, DbContextOptions<TransportationsContext> options)
        : base(options)
    {
        this.dateTimeProvider = dateTimeProvider;
    }

    public DbSet<Transportation>? Transportations { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new TransportationEntityTypeConfiguration());

        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(new AuditableEntitySaveChangesInterceptor(dateTimeProvider));
    }
}
