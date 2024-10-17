using HRMatrix.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HRMatrix.Domain.Configurations;

public class UserProfileSkillConfiguration : IEntityTypeConfiguration<UserProfileSkill>
{
    public void Configure(EntityTypeBuilder<UserProfileSkill> builder)
    {
        builder.HasKey(ups => ups.Id);
        builder.HasOne(ups => ups.UserProfile)
            .WithMany(up => up.UserProfileSkills)
            .HasForeignKey(ups => ups.UserProfileId);

        builder.HasOne(ups => ups.Skill)
            .WithMany()
            .HasForeignKey(ups => ups.SkillId);
    }
}