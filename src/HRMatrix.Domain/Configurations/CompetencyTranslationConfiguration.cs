using HRMatrix.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace HRMatrix.Domain.Configurations;

public class CompetencyTranslationConfiguration : IEntityTypeConfiguration<CompetencyTranslation>
{
    public void Configure(EntityTypeBuilder<CompetencyTranslation> builder)
    {
        builder.HasKey(t => t.Id);

        builder.Property(t => t.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(t => t.LanguageCode)
            .IsRequired()
            .HasMaxLength(10);

        builder.HasOne(t => t.Competency)
            .WithMany(c => c.Translations)
            .HasForeignKey(t => t.CompetencyId);

        builder.HasData(
            new CompetencyTranslation { Id = 1, CompetencyId = 1, Name = "Эффективная коммуникация", LanguageCode = "ru-RU" },
            new CompetencyTranslation { Id = 2, CompetencyId = 1, Name = "Effective Communication", LanguageCode = "en-US" },
            new CompetencyTranslation { Id = 3, CompetencyId = 1, Name = "Натыйжалуу баарлашуу", LanguageCode = "ky-KG" },

            new CompetencyTranslation { Id = 4, CompetencyId = 2, Name = "Клиентоориентированность", LanguageCode = "ru-RU" },
            new CompetencyTranslation { Id = 5, CompetencyId = 2, Name = "Customer Focus", LanguageCode = "en-US" },
            new CompetencyTranslation { Id = 6, CompetencyId = 2, Name = "Кардарга багытталуу", LanguageCode = "ky-KG" },

            new CompetencyTranslation { Id = 7, CompetencyId = 3, Name = "Умение работать в команде", LanguageCode = "ru-RU" },
            new CompetencyTranslation { Id = 8, CompetencyId = 3, Name = "Teamwork", LanguageCode = "en-US" },
            new CompetencyTranslation { Id = 9, CompetencyId = 3, Name = "Командалык иш", LanguageCode = "ky-KG" },

            new CompetencyTranslation { Id = 10, CompetencyId = 4, Name = "Ориентация на результат", LanguageCode = "ru-RU" },
            new CompetencyTranslation { Id = 11, CompetencyId = 4, Name = "Result Orientation", LanguageCode = "en-US" },
            new CompetencyTranslation { Id = 12, CompetencyId = 4, Name = "Жыйынтыкка багытталуу", LanguageCode = "ky-KG" },

            new CompetencyTranslation { Id = 13, CompetencyId = 5, Name = "Негативный настрой (пессимизм)", LanguageCode = "ru-RU" },
            new CompetencyTranslation { Id = 14, CompetencyId = 5, Name = "Negative Attitude (Pessimism)", LanguageCode = "en-US" },
            new CompetencyTranslation { Id = 15, CompetencyId = 5, Name = "Терс маанай (пессимизм)", LanguageCode = "ky-KG" },

            new CompetencyTranslation { Id = 16, CompetencyId = 6, Name = "Равнодушие", LanguageCode = "ru-RU" },
            new CompetencyTranslation { Id = 17, CompetencyId = 6, Name = "Indifference", LanguageCode = "en-US" },
            new CompetencyTranslation { Id = 18, CompetencyId = 6, Name = "Кайдыгерлик", LanguageCode = "ky-KG" },

            new CompetencyTranslation { Id = 19, CompetencyId = 7, Name = "Лицемерие", LanguageCode = "ru-RU" },
            new CompetencyTranslation { Id = 20, CompetencyId = 7, Name = "Hypocrisy", LanguageCode = "en-US" },
            new CompetencyTranslation { Id = 21, CompetencyId = 7, Name = "Экөө сүйлөөчүлүк", LanguageCode = "ky-KG" },

            new CompetencyTranslation { Id = 22, CompetencyId = 8, Name = "Лидерство", LanguageCode = "ru-RU" },
            new CompetencyTranslation { Id = 23, CompetencyId = 8, Name = "Leadership", LanguageCode = "en-US" },
            new CompetencyTranslation { Id = 24, CompetencyId = 8, Name = "Лидерлик", LanguageCode = "ky-KG" },

            new CompetencyTranslation { Id = 25, CompetencyId = 9, Name = "Надежность / Стабильность", LanguageCode = "ru-RU" },
            new CompetencyTranslation { Id = 26, CompetencyId = 9, Name = "Reliability / Stability", LanguageCode = "en-US" },
            new CompetencyTranslation { Id = 27, CompetencyId = 9, Name = "Ишенимдүүлүк / Туруктуулук", LanguageCode = "ky-KG" },

            new CompetencyTranslation { Id = 28, CompetencyId = 10, Name = "Развитие бизнеса / Партнерство", LanguageCode = "ru-RU" },
            new CompetencyTranslation { Id = 29, CompetencyId = 10, Name = "Business Development / Partnership", LanguageCode = "en-US" },
            new CompetencyTranslation { Id = 30, CompetencyId = 10, Name = "Бизнес өнүктүрүү / Өнөктөш", LanguageCode = "ky-KG" },

            new CompetencyTranslation { Id = 31, CompetencyId = 11, Name = "Креативное мышление", LanguageCode = "ru-RU" },
            new CompetencyTranslation { Id = 32, CompetencyId = 11, Name = "Creative Thinking", LanguageCode = "en-US" },
            new CompetencyTranslation { Id = 33, CompetencyId = 11, Name = "Креативдүү ой жүгүртүү", LanguageCode = "ky-KG" },

            new CompetencyTranslation { Id = 34, CompetencyId = 12, Name = "Стратегическое мышление", LanguageCode = "ru-RU" },
            new CompetencyTranslation { Id = 35, CompetencyId = 12, Name = "Strategic Thinking", LanguageCode = "en-US" },
            new CompetencyTranslation { Id = 36, CompetencyId = 12, Name = "Стратегиялык ой жүгүртүү", LanguageCode = "ky-KG" },

            new CompetencyTranslation { Id = 37, CompetencyId = 13, Name = "Самоорганизация", LanguageCode = "ru-RU" },
            new CompetencyTranslation { Id = 38, CompetencyId = 13, Name = "Self-Organization", LanguageCode = "en-US" },
            new CompetencyTranslation { Id = 39, CompetencyId = 13, Name = "Өзүн-өзү уюштуруу", LanguageCode = "ky-KG" }
        );
    }
}