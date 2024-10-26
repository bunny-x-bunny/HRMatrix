using HRMatrix.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace HRMatrix.Domain.Configurations;

public class SpecializationTranslationConfiguration : IEntityTypeConfiguration<SpecializationTranslation>
{
    public void Configure(EntityTypeBuilder<SpecializationTranslation> builder)
    {
        builder.HasKey(t => t.Id);

        builder.Property(t => t.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(t => t.LanguageCode)
            .IsRequired()
            .HasMaxLength(10);

        builder.HasData(
            // FrontEnd Development
            new SpecializationTranslation { Id = 1, SpecializationId = 1, LanguageCode = "ru-RU", Name = "Разработка FrontEnd" },
            new SpecializationTranslation { Id = 2, SpecializationId = 1, LanguageCode = "en-US", Name = "FrontEnd Development" },
            new SpecializationTranslation { Id = 3, SpecializationId = 1, LanguageCode = "ky-KG", Name = "FrontEnd иштеп чыгуу" },

            // BackEnd Development
            new SpecializationTranslation { Id = 4, SpecializationId = 2, LanguageCode = "ru-RU", Name = "Разработка BackEnd" },
            new SpecializationTranslation { Id = 5, SpecializationId = 2, LanguageCode = "en-US", Name = "BackEnd Development" },
            new SpecializationTranslation { Id = 6, SpecializationId = 2, LanguageCode = "ky-KG", Name = "BackEnd иштеп чыгуу" },

            // Data Science and Analysis
            new SpecializationTranslation { Id = 7, SpecializationId = 3, LanguageCode = "ru-RU", Name = "Наука о данных и аналитика" },
            new SpecializationTranslation { Id = 8, SpecializationId = 3, LanguageCode = "en-US", Name = "Data Science and Analysis" },
            new SpecializationTranslation { Id = 9, SpecializationId = 3, LanguageCode = "ky-KG", Name = "Маалымат илими жана аналитика" },

            // Machine Learning and AI
            new SpecializationTranslation { Id = 10, SpecializationId = 4, LanguageCode = "ru-RU", Name = "Машинное обучение и ИИ" },
            new SpecializationTranslation { Id = 11, SpecializationId = 4, LanguageCode = "en-US", Name = "Machine Learning and AI" },
            new SpecializationTranslation { Id = 12, SpecializationId = 4, LanguageCode = "ky-KG", Name = "Машина үйрөнүү жана ЖИ" },

            // DevOps and Cloud Engineering
            new SpecializationTranslation { Id = 13, SpecializationId = 5, LanguageCode = "ru-RU", Name = "DevOps и облачные технологии" },
            new SpecializationTranslation { Id = 14, SpecializationId = 5, LanguageCode = "en-US", Name = "DevOps and Cloud Engineering" },
            new SpecializationTranslation { Id = 15, SpecializationId = 5, LanguageCode = "ky-KG", Name = "DevOps жана булут технологиялары" },

            // Mobile Development
            new SpecializationTranslation { Id = 16, SpecializationId = 6, LanguageCode = "ru-RU", Name = "Мобильная разработка" },
            new SpecializationTranslation { Id = 17, SpecializationId = 6, LanguageCode = "en-US", Name = "Mobile Development" },
            new SpecializationTranslation { Id = 18, SpecializationId = 6, LanguageCode = "ky-KG", Name = "Мобилдик иштеп чыгуу" },

            // Cybersecurity
            new SpecializationTranslation { Id = 19, SpecializationId = 7, LanguageCode = "ru-RU", Name = "Кибербезопасность" },
            new SpecializationTranslation { Id = 20, SpecializationId = 7, LanguageCode = "en-US", Name = "Cybersecurity" },
            new SpecializationTranslation { Id = 21, SpecializationId = 7, LanguageCode = "ky-KG", Name = "Киберкоопсуздук" },

            // Project and Product Management
            new SpecializationTranslation { Id = 22, SpecializationId = 8, LanguageCode = "ru-RU", Name = "Управление проектами и продуктами" },
            new SpecializationTranslation { Id = 23, SpecializationId = 8, LanguageCode = "en-US", Name = "Project and Product Management" },
            new SpecializationTranslation { Id = 24, SpecializationId = 8, LanguageCode = "ky-KG", Name = "Долбоорлорду жана продуктуларды башкаруу" },

            // Networking and IT Support
            new SpecializationTranslation { Id = 25, SpecializationId = 9, LanguageCode = "ru-RU", Name = "Сетевые технологии и поддержка ИТ" },
            new SpecializationTranslation { Id = 26, SpecializationId = 9, LanguageCode = "en-US", Name = "Networking and IT Support" },
            new SpecializationTranslation { Id = 27, SpecializationId = 9, LanguageCode = "ky-KG", Name = "Тармактык технологиялар жана IT колдоо" },

            // Database Management
            new SpecializationTranslation { Id = 28, SpecializationId = 10, LanguageCode = "ru-RU", Name = "Управление базами данных" },
            new SpecializationTranslation { Id = 29, SpecializationId = 10, LanguageCode = "en-US", Name = "Database Management" },
            new SpecializationTranslation { Id = 30, SpecializationId = 10, LanguageCode = "ky-KG", Name = "Маалымат базасын башкаруу" },

            // UI/UX Design
            new SpecializationTranslation { Id = 31, SpecializationId = 11, LanguageCode = "ru-RU", Name = "Дизайн UI/UX" },
            new SpecializationTranslation { Id = 32, SpecializationId = 11, LanguageCode = "en-US", Name = "UI/UX Design" },
            new SpecializationTranslation { Id = 33, SpecializationId = 11, LanguageCode = "ky-KG", Name = "UI/UX Дизайн" },

            // Business Analysis
            new SpecializationTranslation { Id = 34, SpecializationId = 12, LanguageCode = "ru-RU", Name = "Бизнес-анализ" },
            new SpecializationTranslation { Id = 35, SpecializationId = 12, LanguageCode = "en-US", Name = "Business Analysis" },
            new SpecializationTranslation { Id = 36, SpecializationId = 12, LanguageCode = "ky-KG", Name = "Бизнес анализ" }
        );
    }
}