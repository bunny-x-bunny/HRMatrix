using HRMatrix.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace HRMatrix.Domain.Configurations;

public class WorkTypeConfiguration : IEntityTypeConfiguration<WorkType>
{
    public void Configure(EntityTypeBuilder<WorkType> builder)
    {
        builder.HasKey(wt => wt.Id);

        builder.Property(wt => wt.Name)
            .IsRequired()
            .HasMaxLength(50);

        builder.HasData(
            new WorkType { Id = 1, Name = "Полная занятость" },
            new WorkType { Id = 2, Name = "Частичная занятость" },
            new WorkType { Id = 3, Name = "Фриланс" }
        );
    }
}
