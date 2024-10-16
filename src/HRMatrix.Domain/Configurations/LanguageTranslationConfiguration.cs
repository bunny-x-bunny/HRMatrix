using HRMatrix.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace HRMatrix.Domain.Configurations;

public class LanguageTranslationConfiguration : IEntityTypeConfiguration<LanguageTranslation>
{
    public void Configure(EntityTypeBuilder<LanguageTranslation> builder)
    {
        builder.HasKey(lt => lt.Id);
        builder.Property(lt => lt.Name).IsRequired().HasMaxLength(255);
        builder.Property(lt => lt.LanguageCode).IsRequired().HasMaxLength(10);

        builder.HasData(
            new LanguageTranslation { Id = 1, LanguageId = 1, Name = "English", LanguageCode = "en-US" },
            new LanguageTranslation { Id = 2, LanguageId = 1, Name = "Английский", LanguageCode = "ru-RU" },
            new LanguageTranslation { Id = 3, LanguageId = 2, Name = "Turkish", LanguageCode = "en-US" },
            new LanguageTranslation { Id = 4, LanguageId = 2, Name = "Турецкий", LanguageCode = "ru-RU" },
            new LanguageTranslation { Id = 5, LanguageId = 3, Name = "German", LanguageCode = "en-US" },
            new LanguageTranslation { Id = 6, LanguageId = 3, Name = "Немецкий", LanguageCode = "ru-RU" },
            new LanguageTranslation { Id = 7, LanguageId = 4, Name = "Chinese", LanguageCode = "en-US" },
            new LanguageTranslation { Id = 8, LanguageId = 4, Name = "Китайский", LanguageCode = "ru-RU" }
        );
    }
}