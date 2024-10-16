using HRMatrix.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace HRMatrix.Domain.Configurations;

public class FamilyStatusConfiguration : IEntityTypeConfiguration<FamilyStatus>
{
    public void Configure(EntityTypeBuilder<FamilyStatus> builder)
    {
        builder.HasKey(fs => fs.Id);
        
        builder.HasOne(fs => fs.UserProfile)
            .WithOne(up => up.FamilyStatus) 
            .HasForeignKey<FamilyStatus>(fs => fs.UserProfileId);

        builder.HasOne(fs => fs.MaritalStatus)
            .WithMany(ms => ms.FamilyStatuses)
            .HasForeignKey(fs => fs.MaritalStatusId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(fs => fs.TimesMarried).IsRequired();
        builder.Property(fs => fs.MarriagePeriods).HasMaxLength(1000);
        builder.Property(fs => fs.NumberOfChildren).IsRequired();
    }
}