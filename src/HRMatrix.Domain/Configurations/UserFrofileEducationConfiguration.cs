using HRMatrix.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace HRMatrix.Domain.Configurations;

public class UserProfileEducationConfiguration : IEntityTypeConfiguration<UserProfileEducation>
{
    public void Configure(EntityTypeBuilder<UserProfileEducation> builder)
    {
        builder.HasKey(ue => ue.Id);
        builder.HasOne(ue => ue.UserProfile)
            .WithMany(up => up.UserEducations)
            .HasForeignKey(ue => ue.UserProfileId);

        builder.HasOne(ue => ue.EducationLevel)
            .WithMany()
            .HasForeignKey(ue => ue.EducationLevelId);

        builder.Property(ue => ue.Quantity).IsRequired();
    }
}