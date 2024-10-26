using HRMatrix.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace HRMatrix.Domain.Configurations;

public class SpecializationConfiguration : IEntityTypeConfiguration<Specialization>
{
    public void Configure(EntityTypeBuilder<Specialization> builder)
    {
        builder.HasKey(s => s.Id);

        builder.Property(s => s.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.HasMany(s => s.Skills)
            .WithOne(s => s.Specialization)
            .HasForeignKey(s => s.SpecializationId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(s => s.Translations)
            .WithOne(t => t.Specialization)
            .HasForeignKey(t => t.SpecializationId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasData(
            new Specialization { Id = 1, Name = "Разработка FrontEnd" },
            new Specialization { Id = 2, Name = "Разработка BackEnd" },
            new Specialization { Id = 3, Name = "Наука о данных и аналитика" },
            new Specialization { Id = 4, Name = "Машинное обучение и ИИ" },
            new Specialization { Id = 5, Name = "DevOps и облачные технологии" },
            new Specialization { Id = 6, Name = "Мобильная разработка" },
            new Specialization { Id = 7, Name = "Кибербезопасность" },
            new Specialization { Id = 8, Name = "Управление проектами и продуктами" },
            new Specialization { Id = 9, Name = "Сетевые технологии и поддержка ИТ" },
            new Specialization { Id = 10, Name = "Управление базами данных" },
            new Specialization { Id = 11, Name = "Дизайн UI/UX" },
            new Specialization { Id = 12, Name = "Бизнес-анализ" }
        );
    }
}