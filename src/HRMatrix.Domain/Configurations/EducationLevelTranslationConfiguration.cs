using HRMatrix.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HRMatrix.Domain.Configurations;

public class EducationLevelTranslationConfiguration : IEntityTypeConfiguration<EducationLevelTranslation>
{
    public void Configure(EntityTypeBuilder<EducationLevelTranslation> builder)
    {
        builder.HasKey(t => t.Id);
        builder.Property(t => t.Name).IsRequired().HasMaxLength(255);
        builder.Property(t => t.LanguageCode).IsRequired().HasMaxLength(10);

        builder.HasData(
            new EducationLevelTranslation { Id = 1, EducationLevelId = 1, Name = "Высшее законченное (Магистр)", LanguageCode = "ru-RU" },
            new EducationLevelTranslation { Id = 2, EducationLevelId = 1, Name = "Higher Education (Master)", LanguageCode = "en-US" },
            new EducationLevelTranslation { Id = 3, EducationLevelId = 1, Name = "Жогорку билим (Магистр)", LanguageCode = "ky-KG" },

            new EducationLevelTranslation { Id = 4, EducationLevelId = 2, Name = "Среднее специальное / профессиональное", LanguageCode = "ru-RU" },
            new EducationLevelTranslation { Id = 5, EducationLevelId = 2, Name = "Specialized Secondary / Professional", LanguageCode = "en-US" },
            new EducationLevelTranslation { Id = 6, EducationLevelId = 2, Name = "Орточо кесиптик билим", LanguageCode = "ky-KG" },

            new EducationLevelTranslation { Id = 7, EducationLevelId = 3, Name = "Кандидат наук", LanguageCode = "ru-RU" },
            new EducationLevelTranslation { Id = 8, EducationLevelId = 3, Name = "Candidate of Sciences", LanguageCode = "en-US" },
            new EducationLevelTranslation { Id = 9, EducationLevelId = 3, Name = "Илим кандидаты", LanguageCode = "ky-KG" },

            new EducationLevelTranslation { Id = 10, EducationLevelId = 4, Name = "Доктор наук", LanguageCode = "ru-RU" },
            new EducationLevelTranslation { Id = 11, EducationLevelId = 4, Name = "Doctor of Sciences", LanguageCode = "en-US" },
            new EducationLevelTranslation { Id = 12, EducationLevelId = 4, Name = "Илим доктору", LanguageCode = "ky-KG" },

            new EducationLevelTranslation { Id = 13, EducationLevelId = 5, Name = "Доцент", LanguageCode = "ru-RU" },
            new EducationLevelTranslation { Id = 14, EducationLevelId = 5, Name = "Associate Professor", LanguageCode = "en-US" },
            new EducationLevelTranslation { Id = 15, EducationLevelId = 5, Name = "Ассистент профессор", LanguageCode = "ky-KG" }
        );
    }
}