using Manufacturing.Common.Infrastructure.Converters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProcessingMachines.Domain.Entities;
using ProcessingMachines.Domain.Entities.ProcessingOperations;

namespace ProcessingMachines.Infrastructure.Database;

public class ProcessEntityTypeConfiguration : IEntityTypeConfiguration<Process>
{
    public void Configure(EntityTypeBuilder<Process> builder)
    {
        builder.HasKey(process => process.Id);

        builder
            .Property(process => process.OperationsPlan)
            .HasConversion(new EnumListConverter<ProcessingOperation>());
    }
}
