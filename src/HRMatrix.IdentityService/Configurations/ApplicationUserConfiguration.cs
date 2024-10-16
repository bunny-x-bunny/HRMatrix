using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using HRMatrix.IdentityService.Models;

namespace HRMatrix.IdentityService.Configurations;

public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
{
    private readonly PasswordHasher<ApplicationUser> ph = new();

    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        builder.ToTable("users");

        var user = new ApplicationUser
        {
            Id = 1,
            Email = "user@mail.com",
            NormalizedEmail = "USER@MAIL.COM",
            UserName = "user",
            SecurityStamp = Guid.NewGuid().ToString("D"),
            NormalizedUserName = "USER"
        };
        user.PasswordHash = ph.HashPassword(user, "User@123");

        var superUser = new ApplicationUser
        {
            Id = 2,
            Email = "superuser@mail.com",
            NormalizedEmail = "SUPERUSER@MAIL.COM",
            UserName = "superuser",
            SecurityStamp = Guid.NewGuid().ToString("D"),
            NormalizedUserName = "SUPERUSER"
        };
        superUser.PasswordHash = ph.HashPassword(superUser, "SuperUser@123");

        var hr = new ApplicationUser
        {
            Id = 3,
            Email = "hr@mail.com",
            NormalizedEmail = "HR@MAIL.COM",
            UserName = "hr",
            SecurityStamp = Guid.NewGuid().ToString("D"),
            NormalizedUserName = "HR"
        };
        hr.PasswordHash = ph.HashPassword(hr, "Hr@123");

        var admin = new ApplicationUser
        {
            Id = 4,
            Email = "admin@mail.com",
            NormalizedEmail = "ADMIN@MAIL.COM",
            UserName = "admin",
            SecurityStamp = Guid.NewGuid().ToString("D"),
            NormalizedUserName = "ADMIN"
        };
        admin.PasswordHash = ph.HashPassword(admin, "Admin@123");

        builder.HasData(user, superUser, hr, admin);
    }
}
