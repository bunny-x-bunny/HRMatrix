using HRMatrix.IdentityService.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace HRMatrix.IdentityService.Configurations;

public class RoleRequestConfiguration : IEntityTypeConfiguration<RoleRequest>
{
    public void Configure(EntityTypeBuilder<RoleRequest> builder)
    {
        builder.ToTable("role_requests");

        builder.HasKey(r => r.Id);

        builder.HasOne(r => r.User)
            .WithMany()
            .HasForeignKey(r => r.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Property(r => r.RoleName)
            .IsRequired();

        builder.Property(r => r.Status)
            .HasMaxLength(50)
            .IsRequired();
    }
}
