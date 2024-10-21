using HRMatrix.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace HRMatrix.Domain.Configurations;

public class CompetencyConfiguration : IEntityTypeConfiguration<Competency>
{
    public void Configure(EntityTypeBuilder<Competency> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.HasData(
            new Competency { Id = 1, Name = "Эффективная коммуникация" },
            new Competency { Id = 2, Name = "Клиентоориентированность" },
            new Competency { Id = 3, Name = "Умение работать в команде" },
            new Competency { Id = 4, Name = "Ориентация на результат" },
            new Competency { Id = 5, Name = "Негативный настрой (пессимизм)" },
            new Competency { Id = 6, Name = "Равнодушие" },
            new Competency { Id = 7, Name = "Лицемерие" },
            new Competency { Id = 8, Name = "Лидерство" },
            new Competency { Id = 9, Name = "Надежность / Стабильность" },
            new Competency { Id = 10, Name = "Развитие бизнеса / Партнерство" },
            new Competency { Id = 11, Name = "Креативное мышление" },
            new Competency { Id = 12, Name = "Стратегическое мышление" },
            new Competency { Id = 13, Name = "Самоорганизация" }
        );
    }
}