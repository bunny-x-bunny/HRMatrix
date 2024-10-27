using HRMatrix.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace HRMatrix.Domain.Configurations;

public class WorkTypeTranslationConfiguration : IEntityTypeConfiguration<WorkTypeTranslation>
{
    public void Configure(EntityTypeBuilder<WorkTypeTranslation> builder)
    {
        builder.HasKey(wtt => wtt.Id);

        builder.Property(wtt => wtt.Name)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(wtt => wtt.LanguageCode)
            .IsRequired()
            .HasMaxLength(10);

        builder.HasOne(wtt => wtt.WorkType)
            .WithMany(wt => wt.Translations)
            .HasForeignKey(wtt => wtt.WorkTypeId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasData(
            new WorkTypeTranslation { Id = 1, WorkTypeId = 1, Name = "Полная занятость", LanguageCode = "ru-RU" },
            new WorkTypeTranslation { Id = 2, WorkTypeId = 1, Name = "Full-time", LanguageCode = "en-US" },
            new WorkTypeTranslation { Id = 3, WorkTypeId = 1, Name = "Толук жумуш убактысы", LanguageCode = "ky-KG" },
            
            new WorkTypeTranslation { Id = 4, WorkTypeId = 2, Name = "Частичная занятость", LanguageCode = "ru-RU" },
            new WorkTypeTranslation { Id = 5, WorkTypeId = 2, Name = "Part-time", LanguageCode = "en-US" },
            new WorkTypeTranslation { Id = 6, WorkTypeId = 2, Name = "Жарым-жартылай жумуш", LanguageCode = "ky-KG" },
            
            new WorkTypeTranslation { Id = 7, WorkTypeId = 3, Name = "Фриланс", LanguageCode = "ru-RU" },
            new WorkTypeTranslation { Id = 8, WorkTypeId = 3, Name = "Freelance", LanguageCode = "en-US" },
            new WorkTypeTranslation { Id = 9, WorkTypeId = 3, Name = "Эркин иш", LanguageCode = "ky-KG" }
        );
    }
}