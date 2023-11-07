using Manufacturing.Common.Infrastructure.Interceptors;
using Manufacturing.Common.Infrastructure.Providers;
using MaterialsWarehouse.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MaterialsWarehouse.Infrastructure.Database
{
    public class MaterialsContext : DbContext
    {
        private readonly IDateTimeProvider dateTimeProvider;
        
        public MaterialsContext(IDateTimeProvider dateTimeProvider, DbContextOptions<MaterialsContext> options)
            : base(options)
        {
            this.dateTimeProvider = dateTimeProvider;
        }

        public DbSet<Material>? Materials { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MaterialEntityTypeConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.AddInterceptors(new AuditableEntitySaveChangesInterceptor(dateTimeProvider));
        }
    }
}
