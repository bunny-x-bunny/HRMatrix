using HRMatrix.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace HRMatrix.Domain.Configurations;

public class UserProfileLanguageConfiguration : IEntityTypeConfiguration<UserProfileLanguage>
{
    public void Configure(EntityTypeBuilder<UserProfileLanguage> builder)
    {
        builder.HasKey(upl => upl.Id);
        builder.HasOne(upl => upl.UserProfile)
            .WithMany(up => up.UserProfileLanguages)
            .HasForeignKey(upl => upl.UserProfileId);

        builder.HasOne(upl => upl.Language)
            .WithMany()
            .HasForeignKey(upl => upl.LanguageId);
    }
}
