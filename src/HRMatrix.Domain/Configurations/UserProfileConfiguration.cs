using HRMatrix.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace HRMatrix.Domain.Configurations;

public class UserProfileConfiguration : IEntityTypeConfiguration<UserProfile>
{
    public void Configure(EntityTypeBuilder<UserProfile> builder)
    {
        builder.HasKey(up => up.Id);
        builder.Property(up => up.FirstName).IsRequired().HasMaxLength(100);
        builder.Property(up => up.LastName).IsRequired().HasMaxLength(100);
        builder.Property(up => up.DateOfBirth).IsRequired();
        builder.Property(up => up.ProfilePhotoPath).HasMaxLength(255);
        builder.Property(up => up.VideoPath).HasMaxLength(255);
    }
}