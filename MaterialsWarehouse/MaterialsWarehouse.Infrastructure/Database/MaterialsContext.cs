using MaterialsWarehouse.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MaterialsWarehouse.Infrastructure.Database
{
    public class MaterialsContext : DbContext
    {
        public MaterialsContext(DbContextOptions<MaterialsContext> options)
            : base(options)
        {
        }

        public DbSet<Material>? Materials { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MaterialEntityTypeConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
