using HRMatrix.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace HRMatrix.Domain.Configurations;

public class UserProfileCompetencyConfiguration : IEntityTypeConfiguration<UserProfileCompetency>
{
    public void Configure(EntityTypeBuilder<UserProfileCompetency> builder)
    {
        builder.HasKey(upc => upc.Id);

        builder.HasOne(upc => upc.UserProfile)
            .WithMany(up => up.UserProfileCompetencies)
            .HasForeignKey(upc => upc.UserProfileId);

        builder.HasOne(upc => upc.Competency)
            .WithMany()
            .HasForeignKey(upc => upc.CompetencyId);

        builder.Property(upc => upc.ProficiencyLevel)
            .IsRequired();
    }
}