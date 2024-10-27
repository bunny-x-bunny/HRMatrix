using HRMatrix.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace HRMatrix.Domain.Configurations;

public class OrderSkillConfiguration : IEntityTypeConfiguration<OrderSkill>
{
    public void Configure(EntityTypeBuilder<OrderSkill> builder)
    {
        builder.HasKey(os => new { os.OrderId, os.SkillId });
        
        builder.HasOne(os => os.Order)
            .WithMany(o => o.OrderSkills)
            .HasForeignKey(os => os.OrderId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasOne(os => os.Skill)
            .WithMany()
            .HasForeignKey(os => os.SkillId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}