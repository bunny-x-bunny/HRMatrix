using HRMatrix.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace HRMatrix.Domain.Configurations;

public class CityTranslationConfiguration : IEntityTypeConfiguration<CityTranslation>
{
    public void Configure(EntityTypeBuilder<CityTranslation> builder)
    {
        builder.HasKey(t => t.Id);

        builder.Property(t => t.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(t => t.LanguageCode)
            .IsRequired()
            .HasMaxLength(10);

        builder.HasData(
            new CityTranslation { Id = 1, CityId = 1, LanguageCode = "en-US", Name = "Moscow" },
            new CityTranslation { Id = 2, CityId = 1, LanguageCode = "ru-RU", Name = "Москва" },
            new CityTranslation { Id = 3, CityId = 1, LanguageCode = "ky-KG", Name = "Москва" },

            new CityTranslation { Id = 4, CityId = 2, LanguageCode = "en-US", Name = "Saint Petersburg" },
            new CityTranslation { Id = 5, CityId = 2, LanguageCode = "ru-RU", Name = "Санкт-Петербург" },
            new CityTranslation { Id = 6, CityId = 2, LanguageCode = "ky-KG", Name = "Санкт-Петербург" },

            new CityTranslation { Id = 7, CityId = 3, LanguageCode = "en-US", Name = "Almaty" },
            new CityTranslation { Id = 8, CityId = 3, LanguageCode = "ru-RU", Name = "Алматы" },
            new CityTranslation { Id = 9, CityId = 3, LanguageCode = "ky-KG", Name = "Алматы" },

            new CityTranslation { Id = 10, CityId = 4, LanguageCode = "en-US", Name = "Nur-Sultan" },
            new CityTranslation { Id = 11, CityId = 4, LanguageCode = "ru-RU", Name = "Нур-Султан" },
            new CityTranslation { Id = 12, CityId = 4, LanguageCode = "ky-KG", Name = "Нур-Султан" },

            new CityTranslation { Id = 13, CityId = 5, LanguageCode = "en-US", Name = "Minsk" },
            new CityTranslation { Id = 14, CityId = 5, LanguageCode = "ru-RU", Name = "Минск" },
            new CityTranslation { Id = 15, CityId = 5, LanguageCode = "ky-KG", Name = "Минск" },

            new CityTranslation { Id = 16, CityId = 6, LanguageCode = "en-US", Name = "Gomel" },
            new CityTranslation { Id = 17, CityId = 6, LanguageCode = "ru-RU", Name = "Гомель" },
            new CityTranslation { Id = 18, CityId = 6, LanguageCode = "ky-KG", Name = "Гомель" },

            new CityTranslation { Id = 19, CityId = 7, LanguageCode = "en-US", Name = "Kyiv" },
            new CityTranslation { Id = 20, CityId = 7, LanguageCode = "ru-RU", Name = "Киев" },
            new CityTranslation { Id = 21, CityId = 7, LanguageCode = "ky-KG", Name = "Киев" },

            new CityTranslation { Id = 22, CityId = 8, LanguageCode = "en-US", Name = "Odessa" },
            new CityTranslation { Id = 23, CityId = 8, LanguageCode = "ru-RU", Name = "Одесса" },
            new CityTranslation { Id = 24, CityId = 8, LanguageCode = "ky-KG", Name = "Одесса" },

            new CityTranslation { Id = 25, CityId = 9, LanguageCode = "en-US", Name = "Tashkent" },
            new CityTranslation { Id = 26, CityId = 9, LanguageCode = "ru-RU", Name = "Ташкент" },
            new CityTranslation { Id = 27, CityId = 9, LanguageCode = "ky-KG", Name = "Ташкент" },

            new CityTranslation { Id = 28, CityId = 10, LanguageCode = "en-US", Name = "Samarkand" },
            new CityTranslation { Id = 29, CityId = 10, LanguageCode = "ru-RU", Name = "Самарканд" },
            new CityTranslation { Id = 30, CityId = 10, LanguageCode = "ky-KG", Name = "Самарканд" },

            new CityTranslation { Id = 31, CityId = 11, LanguageCode = "en-US", Name = "Bishkek" },
            new CityTranslation { Id = 32, CityId = 11, LanguageCode = "ru-RU", Name = "Бишкек" },
            new CityTranslation { Id = 33, CityId = 11, LanguageCode = "ky-KG", Name = "Бишкек" },

            new CityTranslation { Id = 34, CityId = 12, LanguageCode = "en-US", Name = "Osh" },
            new CityTranslation { Id = 35, CityId = 12, LanguageCode = "ru-RU", Name = "Ош" },
            new CityTranslation { Id = 36, CityId = 12, LanguageCode = "ky-KG", Name = "Ош" },

            new CityTranslation { Id = 37, CityId = 13, LanguageCode = "en-US", Name = "Dushanbe" },
            new CityTranslation { Id = 38, CityId = 13, LanguageCode = "ru-RU", Name = "Душанбе" },
            new CityTranslation { Id = 39, CityId = 13, LanguageCode = "ky-KG", Name = "Душанбе" },

            new CityTranslation { Id = 40, CityId = 14, LanguageCode = "en-US", Name = "Khujand" },
            new CityTranslation { Id = 41, CityId = 14, LanguageCode = "ru-RU", Name = "Худжанд" },
            new CityTranslation { Id = 42, CityId = 14, LanguageCode = "ky-KG", Name = "Худжанд" },

            new CityTranslation { Id = 43, CityId = 15, LanguageCode = "en-US", Name = "Yerevan" },
            new CityTranslation { Id = 44, CityId = 15, LanguageCode = "ru-RU", Name = "Ереван" },
            new CityTranslation { Id = 45, CityId = 15, LanguageCode = "ky-KG", Name = "Ереван" },

            new CityTranslation { Id = 46, CityId = 16, LanguageCode = "en-US", Name = "Gyumri" },
            new CityTranslation { Id = 47, CityId = 16, LanguageCode = "ru-RU", Name = "Гюмри" },
            new CityTranslation { Id = 48, CityId = 16, LanguageCode = "ky-KG", Name = "Гюмри" },

            new CityTranslation { Id = 49, CityId = 17, LanguageCode = "en-US", Name = "Baku" },
            new CityTranslation { Id = 50, CityId = 17, LanguageCode = "ru-RU", Name = "Баку" },
            new CityTranslation { Id = 51, CityId = 17, LanguageCode = "ky-KG", Name = "Баку" },

            new CityTranslation { Id = 52, CityId = 18, LanguageCode = "en-US", Name = "Ganja" },
            new CityTranslation { Id = 53, CityId = 18, LanguageCode = "ru-RU", Name = "Гянджа" },
            new CityTranslation { Id = 54, CityId = 18, LanguageCode = "ky-KG", Name = "Гянджа" },

            new CityTranslation { Id = 55, CityId = 19, LanguageCode = "en-US", Name = "Chisinau" },
            new CityTranslation { Id = 56, CityId = 19, LanguageCode = "ru-RU", Name = "Кишинёв" },
            new CityTranslation { Id = 57, CityId = 19, LanguageCode = "ky-KG", Name = "Кишинёв" },

            new CityTranslation { Id = 58, CityId = 20, LanguageCode = "en-US", Name = "Balti" },
            new CityTranslation { Id = 59, CityId = 20, LanguageCode = "ru-RU", Name = "Бельцы" },
            new CityTranslation { Id = 60, CityId = 20, LanguageCode = "ky-KG", Name = "Бельцы" }
        );
    }
}