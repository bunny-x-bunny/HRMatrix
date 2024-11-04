using HRMatrix.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace HRMatrix.Domain.Configurations;

public class CountryConfiguration : IEntityTypeConfiguration<Country>
{
    public void Configure(EntityTypeBuilder<Country> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.HasMany(c => c.Cities)
            .WithOne(c => c.Country)
            .HasForeignKey(c => c.CountryId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(c => c.Translations)
            .WithOne(t => t.Country)
            .HasForeignKey(t => t.CountryId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasData(
            new Country { Id = 1, Name = "Россия" },
            new Country { Id = 2, Name = "Казахстан" },
            new Country { Id = 3, Name = "Беларусь" },
            new Country { Id = 4, Name = "Украина" },
            new Country { Id = 5, Name = "Узбекистан" },
            new Country { Id = 6, Name = "Кыргызстан" },
            new Country { Id = 7, Name = "Таджикистан" },
            new Country { Id = 8, Name = "Армения" },
            new Country { Id = 9, Name = "Азербайджан" },
            new Country { Id = 10, Name = "Молдова" }
        );
    }
}