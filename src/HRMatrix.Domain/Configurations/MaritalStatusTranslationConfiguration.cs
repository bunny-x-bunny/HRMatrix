using HRMatrix.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace HRMatrix.Domain.Configurations;

public class MaritalStatusTranslationConfiguration : IEntityTypeConfiguration<MaritalStatusTranslation>
{
    public void Configure(EntityTypeBuilder<MaritalStatusTranslation> builder)
    {
        builder.HasKey(t => t.Id);
        builder.Property(t => t.Name).IsRequired().HasMaxLength(255);
        builder.Property(t => t.LanguageCode).IsRequired().HasMaxLength(10);

        builder.HasData(
            new MaritalStatusTranslation { Id = 1, MaritalStatusId = 1, Name = "Married", LanguageCode = "en-US" },
            new MaritalStatusTranslation { Id = 2, MaritalStatusId = 1, Name = "Күйөөм (Замужем)", LanguageCode = "ky-KG" },
            new MaritalStatusTranslation { Id = 3, MaritalStatusId = 1, Name = "Женат/Замужем", LanguageCode = "ru-RU" },

            new MaritalStatusTranslation { Id = 4, MaritalStatusId = 2, Name = "Single", LanguageCode = "en-US" },
            new MaritalStatusTranslation { Id = 5, MaritalStatusId = 2, Name = "Бекар", LanguageCode = "ky-KG" },
            new MaritalStatusTranslation { Id = 6, MaritalStatusId = 2, Name = "Холост/Не замужем", LanguageCode = "ru-RU" },

            new MaritalStatusTranslation { Id = 7, MaritalStatusId = 3, Name = "Divorced", LanguageCode = "en-US" },
            new MaritalStatusTranslation { Id = 8, MaritalStatusId = 3, Name = "Ажыратылган", LanguageCode = "ky-KG" },
            new MaritalStatusTranslation { Id = 9, MaritalStatusId = 3, Name = "Разведен(а)", LanguageCode = "ru-RU" }
        );
    }
}