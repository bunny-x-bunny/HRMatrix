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
            new LanguageTranslation { Id = 1, LanguageId = 1, Name = "Английский", LanguageCode = "ru-RU" },
            new LanguageTranslation { Id = 2, LanguageId = 1, Name = "English", LanguageCode = "en-US" },
            new LanguageTranslation { Id = 3, LanguageId = 1, Name = "Англисче", LanguageCode = "kg-KG" },

            new LanguageTranslation { Id = 4, LanguageId = 2, Name = "Турецкий", LanguageCode = "ru-RU" },
            new LanguageTranslation { Id = 5, LanguageId = 2, Name = "Turkish", LanguageCode = "en-US" },
            new LanguageTranslation { Id = 6, LanguageId = 2, Name = "Түркчө", LanguageCode = "kg-KG" },

            new LanguageTranslation { Id = 7, LanguageId = 3, Name = "Немецкий", LanguageCode = "ru-RU" },
            new LanguageTranslation { Id = 8, LanguageId = 3, Name = "German", LanguageCode = "en-US" },
            new LanguageTranslation { Id = 9, LanguageId = 3, Name = "Немисче", LanguageCode = "kg-KG" },

            new LanguageTranslation { Id = 10, LanguageId = 4, Name = "Китайский", LanguageCode = "ru-RU" },
            new LanguageTranslation { Id = 11, LanguageId = 4, Name = "Chinese", LanguageCode = "en-US" },
            new LanguageTranslation { Id = 12, LanguageId = 4, Name = "Кытайча", LanguageCode = "kg-KG" },

            new LanguageTranslation { Id = 13, LanguageId = 5, Name = "Испанский", LanguageCode = "ru-RU" },
            new LanguageTranslation { Id = 14, LanguageId = 5, Name = "Spanish", LanguageCode = "en-US" },
            new LanguageTranslation { Id = 15, LanguageId = 5, Name = "Испанча", LanguageCode = "kg-KG" },

            new LanguageTranslation { Id = 16, LanguageId = 6, Name = "Французский", LanguageCode = "ru-RU" },
            new LanguageTranslation { Id = 17, LanguageId = 6, Name = "French", LanguageCode = "en-US" },
            new LanguageTranslation { Id = 18, LanguageId = 6, Name = "Французча", LanguageCode = "kg-KG" },

            new LanguageTranslation { Id = 19, LanguageId = 7, Name = "Итальянский", LanguageCode = "ru-RU" },
            new LanguageTranslation { Id = 20, LanguageId = 7, Name = "Italian", LanguageCode = "en-US" },
            new LanguageTranslation { Id = 21, LanguageId = 7, Name = "Итальяныча", LanguageCode = "kg-KG" },

            new LanguageTranslation { Id = 22, LanguageId = 8, Name = "Португальский", LanguageCode = "ru-RU" },
            new LanguageTranslation { Id = 23, LanguageId = 8, Name = "Portuguese", LanguageCode = "en-US" },
            new LanguageTranslation { Id = 24, LanguageId = 8, Name = "Португалча", LanguageCode = "kg-KG" },

            new LanguageTranslation { Id = 25, LanguageId = 9, Name = "Русский", LanguageCode = "ru-RU" },
            new LanguageTranslation { Id = 26, LanguageId = 9, Name = "Russian", LanguageCode = "en-US" },
            new LanguageTranslation { Id = 27, LanguageId = 9, Name = "Орусча", LanguageCode = "kg-KG" },

            new LanguageTranslation { Id = 28, LanguageId = 10, Name = "Японский", LanguageCode = "ru-RU" },
            new LanguageTranslation { Id = 29, LanguageId = 10, Name = "Japanese", LanguageCode = "en-US" },
            new LanguageTranslation { Id = 30, LanguageId = 10, Name = "Жапонча", LanguageCode = "kg-KG" },

            new LanguageTranslation { Id = 31, LanguageId = 11, Name = "Корейский", LanguageCode = "ru-RU" },
            new LanguageTranslation { Id = 32, LanguageId = 11, Name = "Korean", LanguageCode = "en-US" },
            new LanguageTranslation { Id = 33, LanguageId = 11, Name = "Кореяча", LanguageCode = "kg-KG" },

            new LanguageTranslation { Id = 34, LanguageId = 12, Name = "Арабский", LanguageCode = "ru-RU" },
            new LanguageTranslation { Id = 35, LanguageId = 12, Name = "Arabic", LanguageCode = "en-US" },
            new LanguageTranslation { Id = 36, LanguageId = 12, Name = "Арабча", LanguageCode = "kg-KG" },

            new LanguageTranslation { Id = 37, LanguageId = 13, Name = "Голландский", LanguageCode = "ru-RU" },
            new LanguageTranslation { Id = 38, LanguageId = 13, Name = "Dutch", LanguageCode = "en-US" },
            new LanguageTranslation { Id = 39, LanguageId = 13, Name = "Голландча", LanguageCode = "kg-KG" },

            new LanguageTranslation { Id = 40, LanguageId = 14, Name = "Греческий", LanguageCode = "ru-RU" },
            new LanguageTranslation { Id = 41, LanguageId = 14, Name = "Greek", LanguageCode = "en-US" },
            new LanguageTranslation { Id = 42, LanguageId = 14, Name = "Грекче", LanguageCode = "kg-KG" },

            new LanguageTranslation { Id = 43, LanguageId = 15, Name = "Хинди", LanguageCode = "ru-RU" },
            new LanguageTranslation { Id = 44, LanguageId = 15, Name = "Hindi", LanguageCode = "en-US" },
            new LanguageTranslation { Id = 45, LanguageId = 15, Name = "Хиндиче", LanguageCode = "kg-KG" },

            new LanguageTranslation { Id = 46, LanguageId = 16, Name = "Шведский", LanguageCode = "ru-RU" },
            new LanguageTranslation { Id = 47, LanguageId = 16, Name = "Swedish", LanguageCode = "en-US" },
            new LanguageTranslation { Id = 48, LanguageId = 16, Name = "Шведче", LanguageCode = "kg-KG" },

            new LanguageTranslation { Id = 49, LanguageId = 17, Name = "Норвежский", LanguageCode = "ru-RU" },
            new LanguageTranslation { Id = 50, LanguageId = 17, Name = "Norwegian", LanguageCode = "en-US" },
            new LanguageTranslation { Id = 51, LanguageId = 17, Name = "Норвегче", LanguageCode = "kg-KG" },

            new LanguageTranslation { Id = 52, LanguageId = 18, Name = "Датский", LanguageCode = "ru-RU" },
            new LanguageTranslation { Id = 53, LanguageId = 18, Name = "Danish", LanguageCode = "en-US" },
            new LanguageTranslation { Id = 54, LanguageId = 18, Name = "Данияча", LanguageCode = "kg-KG" },

            new LanguageTranslation { Id = 55, LanguageId = 19, Name = "Финский", LanguageCode = "ru-RU" },
            new LanguageTranslation { Id = 56, LanguageId = 19, Name = "Finnish", LanguageCode = "en-US" },
            new LanguageTranslation { Id = 57, LanguageId = 19, Name = "Финче", LanguageCode = "kg-KG" },

            new LanguageTranslation { Id = 58, LanguageId = 20, Name = "Польский", LanguageCode = "ru-RU" },
            new LanguageTranslation { Id = 59, LanguageId = 20, Name = "Polish", LanguageCode = "en-US" },
            new LanguageTranslation { Id = 60, LanguageId = 20, Name = "Полякча", LanguageCode = "kg-KG" },

            new LanguageTranslation { Id = 61, LanguageId = 21, Name = "Чешский", LanguageCode = "ru-RU" },
            new LanguageTranslation { Id = 62, LanguageId = 21, Name = "Czech", LanguageCode = "en-US" },
            new LanguageTranslation { Id = 63, LanguageId = 21, Name = "Чехче", LanguageCode = "kg-KG" },

            new LanguageTranslation { Id = 64, LanguageId = 22, Name = "Словацкий", LanguageCode = "ru-RU" },
            new LanguageTranslation { Id = 65, LanguageId = 22, Name = "Slovak", LanguageCode = "en-US" },
            new LanguageTranslation { Id = 66, LanguageId = 22, Name = "Словакча", LanguageCode = "kg-KG" },

            new LanguageTranslation { Id = 67, LanguageId = 23, Name = "Украинский", LanguageCode = "ru-RU" },
            new LanguageTranslation { Id = 68, LanguageId = 23, Name = "Ukrainian", LanguageCode = "en-US" },
            new LanguageTranslation { Id = 69, LanguageId = 23, Name = "Украинча", LanguageCode = "kg-KG" },

            new LanguageTranslation { Id = 70, LanguageId = 24, Name = "Белорусский", LanguageCode = "ru-RU" },
            new LanguageTranslation { Id = 71, LanguageId = 24, Name = "Belarusian", LanguageCode = "en-US" },
            new LanguageTranslation { Id = 72, LanguageId = 24, Name = "Белорусча", LanguageCode = "kg-KG" },

            new LanguageTranslation { Id = 73, LanguageId = 25, Name = "Венгерский", LanguageCode = "ru-RU" },
            new LanguageTranslation { Id = 74, LanguageId = 25, Name = "Hungarian", LanguageCode = "en-US" },
            new LanguageTranslation { Id = 75, LanguageId = 25, Name = "Венгриче", LanguageCode = "kg-KG" },

            new LanguageTranslation { Id = 76, LanguageId = 26, Name = "Румынский", LanguageCode = "ru-RU" },
            new LanguageTranslation { Id = 77, LanguageId = 26, Name = "Romanian", LanguageCode = "en-US" },
            new LanguageTranslation { Id = 78, LanguageId = 26, Name = "Румынияча", LanguageCode = "kg-KG" },

            new LanguageTranslation { Id = 79, LanguageId = 27, Name = "Болгарский", LanguageCode = "ru-RU" },
            new LanguageTranslation { Id = 80, LanguageId = 27, Name = "Bulgarian", LanguageCode = "en-US" },
            new LanguageTranslation { Id = 81, LanguageId = 27, Name = "Болгарча", LanguageCode = "kg-KG" },

            new LanguageTranslation { Id = 82, LanguageId = 28, Name = "Сербский", LanguageCode = "ru-RU" },
            new LanguageTranslation { Id = 83, LanguageId = 28, Name = "Serbian", LanguageCode = "en-US" },
            new LanguageTranslation { Id = 84, LanguageId = 28, Name = "Сербче", LanguageCode = "kg-KG" },

            new LanguageTranslation { Id = 85, LanguageId = 29, Name = "Хорватский", LanguageCode = "ru-RU" },
            new LanguageTranslation { Id = 86, LanguageId = 29, Name = "Croatian", LanguageCode = "en-US" },
            new LanguageTranslation { Id = 87, LanguageId = 29, Name = "Хорватча", LanguageCode = "kg-KG" },

            new LanguageTranslation { Id = 88, LanguageId = 30, Name = "Словенский", LanguageCode = "ru-RU" },
            new LanguageTranslation { Id = 89, LanguageId = 30, Name = "Slovenian", LanguageCode = "en-US" },
            new LanguageTranslation { Id = 90, LanguageId = 30, Name = "Словенча", LanguageCode = "kg-KG" },

            new LanguageTranslation { Id = 91, LanguageId = 31, Name = "Литовский", LanguageCode = "ru-RU" },
            new LanguageTranslation { Id = 92, LanguageId = 31, Name = "Lithuanian", LanguageCode = "en-US" },
            new LanguageTranslation { Id = 93, LanguageId = 31, Name = "Литвача", LanguageCode = "kg-KG" },

            new LanguageTranslation { Id = 94, LanguageId = 32, Name = "Латышский", LanguageCode = "ru-RU" },
            new LanguageTranslation { Id = 95, LanguageId = 32, Name = "Latvian", LanguageCode = "en-US" },
            new LanguageTranslation { Id = 96, LanguageId = 32, Name = "Латышча", LanguageCode = "kg-KG" },

            new LanguageTranslation { Id = 97, LanguageId = 33, Name = "Эстонский", LanguageCode = "ru-RU" },
            new LanguageTranslation { Id = 98, LanguageId = 33, Name = "Estonian", LanguageCode = "en-US" },
            new LanguageTranslation { Id = 99, LanguageId = 33, Name = "Эстонча", LanguageCode = "kg-KG" }
        );
    }
}