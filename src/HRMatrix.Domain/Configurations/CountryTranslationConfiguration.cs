using HRMatrix.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace HRMatrix.Domain.Configurations;

public class CountryTranslationConfiguration : IEntityTypeConfiguration<CountryTranslation>
{
    public void Configure(EntityTypeBuilder<CountryTranslation> builder)
    {
        builder.HasKey(t => t.Id);

        builder.Property(t => t.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(t => t.LanguageCode)
            .IsRequired()
            .HasMaxLength(10);

        builder.HasData(
            new CountryTranslation { Id = 1, CountryId = 1, LanguageCode = "en-US", Name = "Russia" },
            new CountryTranslation { Id = 2, CountryId = 1, LanguageCode = "ru-RU", Name = "Россия" },
            new CountryTranslation { Id = 3, CountryId = 1, LanguageCode = "ky-KG", Name = "Россия" },

            new CountryTranslation { Id = 4, CountryId = 2, LanguageCode = "en-US", Name = "Kazakhstan" },
            new CountryTranslation { Id = 5, CountryId = 2, LanguageCode = "ru-RU", Name = "Казахстан" },
            new CountryTranslation { Id = 6, CountryId = 2, LanguageCode = "ky-KG", Name = "Казакстан" },

            new CountryTranslation { Id = 7, CountryId = 3, LanguageCode = "en-US", Name = "Belarus" },
            new CountryTranslation { Id = 8, CountryId = 3, LanguageCode = "ru-RU", Name = "Беларусь" },
            new CountryTranslation { Id = 9, CountryId = 3, LanguageCode = "ky-KG", Name = "Беларусь" },

            new CountryTranslation { Id = 10, CountryId = 4, LanguageCode = "en-US", Name = "Ukraine" },
            new CountryTranslation { Id = 11, CountryId = 4, LanguageCode = "ru-RU", Name = "Украина" },
            new CountryTranslation { Id = 12, CountryId = 4, LanguageCode = "ky-KG", Name = "Украина" },

            new CountryTranslation { Id = 13, CountryId = 5, LanguageCode = "en-US", Name = "Uzbekistan" },
            new CountryTranslation { Id = 14, CountryId = 5, LanguageCode = "ru-RU", Name = "Узбекистан" },
            new CountryTranslation { Id = 15, CountryId = 5, LanguageCode = "ky-KG", Name = "Өзбекстан" },

            new CountryTranslation { Id = 16, CountryId = 6, LanguageCode = "en-US", Name = "Kyrgyzstan" },
            new CountryTranslation { Id = 17, CountryId = 6, LanguageCode = "ru-RU", Name = "Кыргызстан" },
            new CountryTranslation { Id = 18, CountryId = 6, LanguageCode = "ky-KG", Name = "Кыргызстан" },

            new CountryTranslation { Id = 19, CountryId = 7, LanguageCode = "en-US", Name = "Tajikistan" },
            new CountryTranslation { Id = 20, CountryId = 7, LanguageCode = "ru-RU", Name = "Таджикистан" },
            new CountryTranslation { Id = 21, CountryId = 7, LanguageCode = "ky-KG", Name = "Тажикстан" },

            new CountryTranslation { Id = 22, CountryId = 8, LanguageCode = "en-US", Name = "Armenia" },
            new CountryTranslation { Id = 23, CountryId = 8, LanguageCode = "ru-RU", Name = "Армения" },
            new CountryTranslation { Id = 24, CountryId = 8, LanguageCode = "ky-KG", Name = "Армения" },

            new CountryTranslation { Id = 25, CountryId = 9, LanguageCode = "en-US", Name = "Azerbaijan" },
            new CountryTranslation { Id = 26, CountryId = 9, LanguageCode = "ru-RU", Name = "Азербайджан" },
            new CountryTranslation { Id = 27, CountryId = 9, LanguageCode = "ky-KG", Name = "Азербайжан" },

            new CountryTranslation { Id = 28, CountryId = 10, LanguageCode = "en-US", Name = "Moldova" },
            new CountryTranslation { Id = 29, CountryId = 10, LanguageCode = "ru-RU", Name = "Молдова" },
            new CountryTranslation { Id = 30, CountryId = 10, LanguageCode = "ky-KG", Name = "Молдова" }
        );
    }
}