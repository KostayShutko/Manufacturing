using Manufacturing.Common.Infrastructure.Interceptors;
using Manufacturing.Common.Infrastructure.Providers;
using Microsoft.EntityFrameworkCore;
using ProductsWarehouse.Domain.Entities;

namespace ProductsWarehouse.Infrastructure.Database;

public class ProductsContext : DbContext
{
    private readonly IDateTimeProvider dateTimeProvider;

    public ProductsContext(IDateTimeProvider dateTimeProvider, DbContextOptions<ProductsContext> options)
        : base(options)
    {
        this.dateTimeProvider = dateTimeProvider;
    }

    public DbSet<Product>? Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ProductEntityTypeConfiguration());

        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(new AuditableEntitySaveChangesInterceptor(dateTimeProvider));
    }
}
