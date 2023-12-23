using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProcessingMachines.Domain.Entities;

namespace ProcessingMachines.Infrastructure.Database;

public class ProcessEntityTypeConfiguration : IEntityTypeConfiguration<Process>
{
    public void Configure(EntityTypeBuilder<Process> builder)
    {
        builder.HasKey(process => process.Id);
    }
}
