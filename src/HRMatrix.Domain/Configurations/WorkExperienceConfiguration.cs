using HRMatrix.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HRMatrix.Domain.Configurations;

public class WorkExperienceConfiguration : IEntityTypeConfiguration<WorkExperience>
{
    public void Configure(EntityTypeBuilder<WorkExperience> builder)
    {
        builder.HasKey(we => we.Id);
        builder.Property(we => we.CompanyName).IsRequired().HasMaxLength(255);
        builder.Property(we => we.Position).IsRequired().HasMaxLength(100);
        builder.Property(we => we.StartDate).IsRequired();
        builder.Property(we => we.EndDate).IsRequired(false);
        builder.Property(we => we.Achievements).HasMaxLength(1000);

        builder.HasOne(we => we.UserProfile)
            .WithMany(up => up.WorkExperiences)
            .HasForeignKey(we => we.UserProfileId);
    }
}