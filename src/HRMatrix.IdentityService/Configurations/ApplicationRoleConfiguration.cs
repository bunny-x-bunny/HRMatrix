using HRMatrix.IdentityService.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HRMatrix.IdentityService.Configurations;

public class ApplicationRoleConfiguration : IEntityTypeConfiguration<ApplicationRole>
{
    public void Configure(EntityTypeBuilder<ApplicationRole> builder)
    {
        builder.ToTable("roles");

        builder.HasData(
            new ApplicationRole { Id = 1, Name = "User", NormalizedName = "USER" },
            new ApplicationRole { Id = 2, Name = "SuperUser", NormalizedName = "SUPERUSER" },
            new ApplicationRole { Id = 3, Name = "HR", NormalizedName = "HR" },
            new ApplicationRole { Id = 4, Name = "Admin", NormalizedName = "ADMIN" }
        );
    }
}

