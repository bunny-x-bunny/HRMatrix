using HRMatrix.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace HRMatrix.Domain.Configurations;

public class CityConfiguration : IEntityTypeConfiguration<City>
{
    public void Configure(EntityTypeBuilder<City> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.HasOne(c => c.Country)
            .WithMany(c => c.Cities)
            .HasForeignKey(c => c.CountryId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(c => c.Translations)
            .WithOne(t => t.City)
            .HasForeignKey(t => t.CityId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasData(
            new City { Id = 1, Name = "Москва", CountryId = 1 },
            new City { Id = 2, Name = "Санкт-Петербург", CountryId = 1 },
            new City { Id = 3, Name = "Алматы", CountryId = 2 },
            new City { Id = 4, Name = "Нур-Султан", CountryId = 2 },
            new City { Id = 5, Name = "Минск", CountryId = 3 },
            new City { Id = 6, Name = "Гомель", CountryId = 3 },
            new City { Id = 7, Name = "Киев", CountryId = 4 },
            new City { Id = 8, Name = "Одесса", CountryId = 4 },
            new City { Id = 9, Name = "Ташкент", CountryId = 5 },
            new City { Id = 10, Name = "Самарканд", CountryId = 5 },
            new City { Id = 11, Name = "Бишкек", CountryId = 6 },
            new City { Id = 12, Name = "Ош", CountryId = 6 },
            new City { Id = 13, Name = "Душанбе", CountryId = 7 },
            new City { Id = 14, Name = "Худжанд", CountryId = 7 },
            new City { Id = 15, Name = "Ереван", CountryId = 8 },
            new City { Id = 16, Name = "Гюмри", CountryId = 8 },
            new City { Id = 17, Name = "Баку", CountryId = 9 },
            new City { Id = 18, Name = "Гянджа", CountryId = 9 },
            new City { Id = 19, Name = "Кишинёв", CountryId = 10 },
            new City { Id = 20, Name = "Бельцы", CountryId = 10 }
        );
    }
}