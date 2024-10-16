using HRMatrix.IdentityService.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HRMatrix.IdentityService.Configurations;

public class ApplicationUserRoleConfiguration : IEntityTypeConfiguration<ApplicationUserRole>
{
    public void Configure(EntityTypeBuilder<ApplicationUserRole> builder)
    {
        builder.ToTable("user_role");

        builder.HasData
        (
            new ApplicationUserRole { RoleId = 1, UserId = 1 },
            new ApplicationUserRole { RoleId = 2, UserId = 2 },
            new ApplicationUserRole { RoleId = 3, UserId = 3 },
            new ApplicationUserRole { RoleId = 4, UserId = 4 }
        );
    }
}