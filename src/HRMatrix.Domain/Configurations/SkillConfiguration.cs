using HRMatrix.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace HRMatrix.Domain.Configurations;

public class SkillConfiguration : IEntityTypeConfiguration<Skill>
{
    public void Configure(EntityTypeBuilder<Skill> builder)
    {
        builder.HasKey(s => s.Id);

        builder.Property(s => s.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.HasOne(s => s.Specialization)
            .WithMany(s => s.Skills)
            .HasForeignKey(s => s.SpecializationId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasData(
    // Разработка FrontEnd
            new Skill { Id = 1, Name = "JavaScript Разработчик", SpecializationId = 1 },
            new Skill { Id = 2, Name = "HTML/CSS Разработчик", SpecializationId = 1 },

            // Разработка BackEnd
            new Skill { Id = 3, Name = "C# Разработчик", SpecializationId = 2 },
            new Skill { Id = 4, Name = "Java Разработчик", SpecializationId = 2 },

            // Наука о данных и аналитика
            new Skill { Id = 5, Name = "Специалист по данным", SpecializationId = 3 },
            new Skill { Id = 6, Name = "Аналитик данных", SpecializationId = 3 },

            // Машинное обучение и ИИ
            new Skill { Id = 7, Name = "Инженер машинного обучения", SpecializationId = 4 },
            new Skill { Id = 8, Name = "Исследователь ИИ", SpecializationId = 4 },

            // DevOps и облачные технологии
            new Skill { Id = 9, Name = "DevOps инженер", SpecializationId = 5 },
            new Skill { Id = 10, Name = "Облачный инженер", SpecializationId = 5 },

            // Мобильная разработка
            new Skill { Id = 11, Name = "Swift Разработчик", SpecializationId = 6 },
            new Skill { Id = 12, Name = "Android Разработчик", SpecializationId = 6 },

            // Кибербезопасность
            new Skill { Id = 13, Name = "Специалист по кибербезопасности", SpecializationId = 7 },
            new Skill { Id = 14, Name = "Этический хакер", SpecializationId = 7 },

            // Управление проектами и продуктами
            new Skill { Id = 15, Name = "Scrum-мастер", SpecializationId = 8 },
            new Skill { Id = 16, Name = "Владелец продукта", SpecializationId = 8 },

            // Сетевые технологии и поддержка ИТ
            new Skill { Id = 17, Name = "Сетевой инженер", SpecializationId = 9 },
            new Skill { Id = 18, Name = "Администратор сети", SpecializationId = 9 },

            // Управление базами данных
            new Skill { Id = 19, Name = "Администратор базы данных", SpecializationId = 10 },
            new Skill { Id = 20, Name = "Менеджер информационных систем", SpecializationId = 10 },

            // Дизайн UI/UX
            new Skill { Id = 21, Name = "UI/UX дизайнер", SpecializationId = 11 },
            new Skill { Id = 22, Name = "Веб-дизайнер", SpecializationId = 11 },

            // Бизнес-анализ
            new Skill { Id = 23, Name = "Бизнес-аналитик", SpecializationId = 12 },
            new Skill { Id = 24, Name = "Консультант по бизнес-анализу", SpecializationId = 12 }
        );
    }
}