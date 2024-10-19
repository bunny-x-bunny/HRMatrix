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
            NormalizedUserName = "USER",
            FirstName = "John",
            LastName = "Doe",
            DateOfBirth = new DateTime(1990, 1, 1)
        };
        user.PasswordHash = ph.HashPassword(user, "User@123");

        var superUser = new ApplicationUser
        {
            Id = 2,
            Email = "superuser@mail.com",
            NormalizedEmail = "SUPERUSER@MAIL.COM",
            UserName = "superuser",
            SecurityStamp = Guid.NewGuid().ToString("D"),
            NormalizedUserName = "SUPERUSER",
            FirstName = "Jane",
            LastName = "Doe",
            DateOfBirth = new DateTime(1985, 1, 1)
        };
        superUser.PasswordHash = ph.HashPassword(superUser, "SuperUser@123");

        var hr = new ApplicationUser
        {
            Id = 3,
            Email = "hr@mail.com",
            NormalizedEmail = "HR@MAIL.COM",
            UserName = "hr",
            SecurityStamp = Guid.NewGuid().ToString("D"),
            NormalizedUserName = "HR",
            FirstName = "Alice",
            LastName = "Smith",
            DateOfBirth = new DateTime(1992, 1, 1)
        };
        hr.PasswordHash = ph.HashPassword(hr, "Hr@123");

        var admin = new ApplicationUser
        {
            Id = 4,
            Email = "admin@mail.com",
            NormalizedEmail = "ADMIN@MAIL.COM",
            UserName = "admin",
            SecurityStamp = Guid.NewGuid().ToString("D"),
            NormalizedUserName = "ADMIN",
            FirstName = "Bob",
            LastName = "Johnson",
            DateOfBirth = new DateTime(1980, 1, 1)
        };
        admin.PasswordHash = ph.HashPassword(admin, "Admin@123");

        builder.HasData(user, superUser, hr, admin);
    }
}