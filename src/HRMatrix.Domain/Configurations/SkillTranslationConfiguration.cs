using HRMatrix.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace HRMatrix.Domain.Configurations;

public class SkillTranslationConfiguration : IEntityTypeConfiguration<SkillTranslation>
{
    public void Configure(EntityTypeBuilder<SkillTranslation> builder)
    {
        builder.HasKey(t => t.Id);

        builder.Property(t => t.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(t => t.LanguageCode)
            .IsRequired()
            .HasMaxLength(10);

        builder.HasData(
            // Разработка FrontEnd
            new SkillTranslation { Id = 1, SkillId = 1, LanguageCode = "ru-RU", Name = "JavaScript Разработчик" },
            new SkillTranslation { Id = 2, SkillId = 1, LanguageCode = "en-US", Name = "JavaScript Developer" },
            new SkillTranslation { Id = 3, SkillId = 1, LanguageCode = "ky-KG", Name = "JavaScript иштеп чыгуучу" },

            new SkillTranslation { Id = 4, SkillId = 2, LanguageCode = "ru-RU", Name = "HTML/CSS Разработчик" },
            new SkillTranslation { Id = 5, SkillId = 2, LanguageCode = "en-US", Name = "HTML/CSS Developer" },
            new SkillTranslation { Id = 6, SkillId = 2, LanguageCode = "ky-KG", Name = "HTML/CSS иштеп чыгуучу" },

            // Разработка BackEnd
            new SkillTranslation { Id = 7, SkillId = 3, LanguageCode = "ru-RU", Name = "C# Разработчик" },
            new SkillTranslation { Id = 8, SkillId = 3, LanguageCode = "en-US", Name = "C# Developer" },
            new SkillTranslation { Id = 9, SkillId = 3, LanguageCode = "ky-KG", Name = "C# иштеп чыгуучу" },

            new SkillTranslation { Id = 10, SkillId = 4, LanguageCode = "ru-RU", Name = "Java Разработчик" },
            new SkillTranslation { Id = 11, SkillId = 4, LanguageCode = "en-US", Name = "Java Developer" },
            new SkillTranslation { Id = 12, SkillId = 4, LanguageCode = "ky-KG", Name = "Java иштеп чыгуучу" },

            // Наука о данных и аналитика
            new SkillTranslation { Id = 13, SkillId = 5, LanguageCode = "ru-RU", Name = "Специалист по данным" },
            new SkillTranslation { Id = 14, SkillId = 5, LanguageCode = "en-US", Name = "Data Specialist" },
            new SkillTranslation { Id = 15, SkillId = 5, LanguageCode = "ky-KG", Name = "Маалыматтар боюнча адис" },

            new SkillTranslation { Id = 16, SkillId = 6, LanguageCode = "ru-RU", Name = "Аналитик данных" },
            new SkillTranslation { Id = 17, SkillId = 6, LanguageCode = "en-US", Name = "Data Analyst" },
            new SkillTranslation { Id = 18, SkillId = 6, LanguageCode = "ky-KG", Name = "Маалыматтар аналитиги" },

            // Машинное обучение и ИИ
            new SkillTranslation { Id = 19, SkillId = 7, LanguageCode = "ru-RU", Name = "Инженер машинного обучения" },
            new SkillTranslation { Id = 20, SkillId = 7, LanguageCode = "en-US", Name = "Machine Learning Engineer" },
            new SkillTranslation { Id = 21, SkillId = 7, LanguageCode = "ky-KG", Name = "Машиналык үйрөнүү инженери" },

            new SkillTranslation { Id = 22, SkillId = 8, LanguageCode = "ru-RU", Name = "Исследователь ИИ" },
            new SkillTranslation { Id = 23, SkillId = 8, LanguageCode = "en-US", Name = "AI Researcher" },
            new SkillTranslation { Id = 24, SkillId = 8, LanguageCode = "ky-KG", Name = "ИИ изилдөөчүсү" },

            // DevOps и облачные технологии
            new SkillTranslation { Id = 25, SkillId = 9, LanguageCode = "ru-RU", Name = "DevOps инженер" },
            new SkillTranslation { Id = 26, SkillId = 9, LanguageCode = "en-US", Name = "DevOps Engineer" },
            new SkillTranslation { Id = 27, SkillId = 9, LanguageCode = "ky-KG", Name = "DevOps инженери" },

            new SkillTranslation { Id = 28, SkillId = 10, LanguageCode = "ru-RU", Name = "Облачный инженер" },
            new SkillTranslation { Id = 29, SkillId = 10, LanguageCode = "en-US", Name = "Cloud Engineer" },
            new SkillTranslation { Id = 30, SkillId = 10, LanguageCode = "ky-KG", Name = "Булут инженери" },

            // Мобильная разработка
            new SkillTranslation { Id = 31, SkillId = 11, LanguageCode = "ru-RU", Name = "Swift Разработчик" },
            new SkillTranslation { Id = 32, SkillId = 11, LanguageCode = "en-US", Name = "Swift Developer" },
            new SkillTranslation { Id = 33, SkillId = 11, LanguageCode = "ky-KG", Name = "Swift иштеп чыгуучу" },

            new SkillTranslation { Id = 34, SkillId = 12, LanguageCode = "ru-RU", Name = "Android Разработчик" },
            new SkillTranslation { Id = 35, SkillId = 12, LanguageCode = "en-US", Name = "Android Developer" },
            new SkillTranslation { Id = 36, SkillId = 12, LanguageCode = "ky-KG", Name = "Android иштеп чыгуучу" },

            // Кибербезопасность
            new SkillTranslation { Id = 37, SkillId = 13, LanguageCode = "ru-RU", Name = "Специалист по кибербезопасности" },
            new SkillTranslation { Id = 38, SkillId = 13, LanguageCode = "en-US", Name = "Cybersecurity Specialist" },
            new SkillTranslation { Id = 39, SkillId = 13, LanguageCode = "ky-KG", Name = "Киберкоопсуздук адиси" },

            new SkillTranslation { Id = 40, SkillId = 14, LanguageCode = "ru-RU", Name = "Этический хакер" },
            new SkillTranslation { Id = 41, SkillId = 14, LanguageCode = "en-US", Name = "Ethical Hacker" },
            new SkillTranslation { Id = 42, SkillId = 14, LanguageCode = "ky-KG", Name = "Этикалык хакер" },

            // Управление проектами и продуктами
            new SkillTranslation { Id = 43, SkillId = 15, LanguageCode = "ru-RU", Name = "Scrum-мастер" },
            new SkillTranslation { Id = 44, SkillId = 15, LanguageCode = "en-US", Name = "Scrum Master" },
            new SkillTranslation { Id = 45, SkillId = 15, LanguageCode = "ky-KG", Name = "Scrum мастер" },

            new SkillTranslation { Id = 46, SkillId = 16, LanguageCode = "ru-RU", Name = "Владелец продукта" },
            new SkillTranslation { Id = 47, SkillId = 16, LanguageCode = "en-US", Name = "Product Owner" },
            new SkillTranslation { Id = 48, SkillId = 16, LanguageCode = "ky-KG", Name = "Продукт ээси" },

            // Сетевые технологии и поддержка ИТ
            new SkillTranslation { Id = 49, SkillId = 17, LanguageCode = "ru-RU", Name = "Сетевой инженер" },
            new SkillTranslation { Id = 50, SkillId = 17, LanguageCode = "en-US", Name = "Network Engineer" },
            new SkillTranslation { Id = 51, SkillId = 17, LanguageCode = "ky-KG", Name = "Тармак инженери" },

            new SkillTranslation { Id = 52, SkillId = 18, LanguageCode = "ru-RU", Name = "Администратор сети" },
            new SkillTranslation { Id = 53, SkillId = 18, LanguageCode = "en-US", Name = "Network Administrator" },
            new SkillTranslation { Id = 54, SkillId = 18, LanguageCode = "ky-KG", Name = "Тармак администратору" },

            // Управление базами данных
            new SkillTranslation { Id = 55, SkillId = 19, LanguageCode = "ru-RU", Name = "Администратор базы данных" },
            new SkillTranslation { Id = 56, SkillId = 19, LanguageCode = "en-US", Name = "Database Administrator" },
            new SkillTranslation { Id = 57, SkillId = 19, LanguageCode = "ky-KG", Name = "Маалыматтар базасынын администратору" },

            new SkillTranslation { Id = 58, SkillId = 20, LanguageCode = "ru-RU", Name = "Менеджер информационных систем" },
            new SkillTranslation { Id = 59, SkillId = 20, LanguageCode = "en-US", Name = "Information Systems Manager" },
            new SkillTranslation { Id = 60, SkillId = 20, LanguageCode = "ky-KG", Name = "Маалымат системаларынын менеджери" },

            // Дизайн UI/UX
            new SkillTranslation { Id = 61, SkillId = 21, LanguageCode = "ru-RU", Name = "UI/UX дизайнер" },
            new SkillTranslation { Id = 62, SkillId = 21, LanguageCode = "en-US", Name = "UI/UX Designer" },
            new SkillTranslation { Id = 63, SkillId = 21, LanguageCode = "ky-KG", Name = "UI/UX дизайнер" },

            new SkillTranslation { Id = 64, SkillId = 22, LanguageCode = "ru-RU", Name = "Веб-дизайнер" },
            new SkillTranslation { Id = 65, SkillId = 22, LanguageCode = "en-US", Name = "Web Designer" },
            new SkillTranslation { Id = 66, SkillId = 22, LanguageCode = "ky-KG", Name = "Веб-дизайнер" },

            // Бизнес-анализ
            new SkillTranslation { Id = 67, SkillId = 23, LanguageCode = "ru-RU", Name = "Бизнес-аналитик" },
            new SkillTranslation { Id = 68, SkillId = 23, LanguageCode = "en-US", Name = "Business Analyst" },
            new SkillTranslation { Id = 69, SkillId = 23, LanguageCode = "ky-KG", Name = "Бизнес аналитик" },

            new SkillTranslation { Id = 70, SkillId = 24, LanguageCode = "ru-RU", Name = "Консультант по бизнес-анализу" },
            new SkillTranslation { Id = 71, SkillId = 24, LanguageCode = "en-US", Name = "Business Analysis Consultant" },
            new SkillTranslation { Id = 72, SkillId = 24, LanguageCode = "ky-KG", Name = "Бизнес-аналитика боюнча кеңешчи" }
        );
    }
}