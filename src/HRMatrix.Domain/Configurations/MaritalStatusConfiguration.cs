using HRMatrix.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace HRMatrix.Domain.Configurations;

public class MaritalStatusConfiguration : IEntityTypeConfiguration<MaritalStatus>
{
    public void Configure(EntityTypeBuilder<MaritalStatus> builder)
    {
        builder.HasKey(ms => ms.Id);
        builder.Property(ms => ms.Name).IsRequired().HasMaxLength(100);

        builder.HasMany(ms => ms.Translations)
            .WithOne(t => t.MaritalStatus)
            .HasForeignKey(t => t.MaritalStatusId);

        builder.HasData(
            new MaritalStatus { Id = 1, Name = "Женат/Замужем" },
            new MaritalStatus { Id = 2, Name = "Холост/Не замужем" },
            new MaritalStatus { Id = 3, Name = "Разведен(а)" }
        );
    }
}