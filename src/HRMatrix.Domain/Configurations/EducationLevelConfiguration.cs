using HRMatrix.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HRMatrix.Domain.Configurations;

public class EducationLevelConfiguration : IEntityTypeConfiguration<EducationLevel>
{
    public void Configure(EntityTypeBuilder<EducationLevel> builder)
    {
        builder.HasKey(e => e.Id);

        builder.HasMany(e => e.Translations)
            .WithOne(t => t.EducationLevel)
            .HasForeignKey(t => t.EducationLevelId);

        builder.HasData(
            new EducationLevel { Id = 1, Name = "Высшее законченное (Магистр)" },
            new EducationLevel { Id = 2, Name = "Среднее специальное / профессиональное" },
            new EducationLevel { Id = 3, Name = "Кандидат наук" },
            new EducationLevel { Id = 4, Name = "Доктор наук" },
            new EducationLevel { Id = 5, Name = "Доцент" });
    }
}