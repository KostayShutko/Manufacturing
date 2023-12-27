using Manufacturing.Common.Infrastructure.Converters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProcessingMachines.Domain.Entities;

namespace ProcessingMachines.Infrastructure.Database;

public class ProductEntityTypeConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(product => product.Id);

        builder
            .Property(process => process.AppliedOperations)
            .HasConversion(new StringListConverter());
    }
}
