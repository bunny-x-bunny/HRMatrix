using HRMatrix.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace HRMatrix.Domain.Configurations;

public class LanguageConfiguration : IEntityTypeConfiguration<Language>
{
    public void Configure(EntityTypeBuilder<Language> builder)
    {
        builder.HasKey(l => l.Id);
        builder.Property(l => l.Name).IsRequired().HasMaxLength(100);

        builder.HasData(
            new Language { Id = 1, Name = "Английский" },
            new Language { Id = 2, Name = "Турецкий" },
            new Language { Id = 3, Name = "Немецкий" },
            new Language { Id = 4, Name = "Китайский" },
            new Language { Id = 5, Name = "Испанский" },
            new Language { Id = 6, Name = "Французский" },
            new Language { Id = 7, Name = "Итальянский" },
            new Language { Id = 8, Name = "Португальский" },
            new Language { Id = 9, Name = "Русский" },
            new Language { Id = 10, Name = "Японский" },
            new Language { Id = 11, Name = "Корейский" },
            new Language { Id = 12, Name = "Арабский" },
            new Language { Id = 13, Name = "Голландский" },
            new Language { Id = 14, Name = "Греческий" },
            new Language { Id = 15, Name = "Хинди" },
            new Language { Id = 16, Name = "Шведский" },
            new Language { Id = 17, Name = "Норвежский" },
            new Language { Id = 18, Name = "Датский" },
            new Language { Id = 19, Name = "Финский" },
            new Language { Id = 20, Name = "Польский" },
            new Language { Id = 21, Name = "Чешский" },
            new Language { Id = 22, Name = "Словацкий" },
            new Language { Id = 23, Name = "Украинский" },
            new Language { Id = 24, Name = "Белорусский" },
            new Language { Id = 25, Name = "Венгерский" },
            new Language { Id = 26, Name = "Румынский" },
            new Language { Id = 27, Name = "Болгарский" },
            new Language { Id = 28, Name = "Сербский" },
            new Language { Id = 29, Name = "Хорватский" },
            new Language { Id = 30, Name = "Словенский" },
            new Language { Id = 31, Name = "Литовский" },
            new Language { Id = 32, Name = "Латышский" },
            new Language { Id = 33, Name = "Эстонский" }
        );
    }
}