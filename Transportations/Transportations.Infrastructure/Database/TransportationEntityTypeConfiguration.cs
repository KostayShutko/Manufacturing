using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Transportations.Domain.Entities;

namespace Transportations.Infrastructure.Database;

public class TransportationEntityTypeConfiguration : IEntityTypeConfiguration<Transportation>
{
    public void Configure(EntityTypeBuilder<Transportation> builder)
    {
        builder.HasKey(transportation => transportation.Id);
    }
}
