using HRMatrix.IdentityService.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace HRMatrix.IdentityService.Configurations;

public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
{
    private readonly PasswordHasher<ApplicationUser> _ph = new();

    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        builder.ToTable("users");

        builder.HasIndex(u => u.PhoneNumber)
            .IsUnique();

        var user = new ApplicationUser
        {
            Id = 1,
            Email = "user@mail.com",
            NormalizedEmail = "USER@MAIL.COM",
            UserName = "user",
            NormalizedUserName = "USER",
            FirstName = "John",
            LastName = "Doe",
            DateOfBirth = new DateTime(1990, 1, 1),
            SecurityStamp = Guid.NewGuid().ToString("D"),
            PhoneNumber = "1234567890",
            PhoneNumberConfirmed = true
        };
        user.PasswordHash = _ph.HashPassword(user, "User@123");

        var superUser = new ApplicationUser
        {
            Id = 2,
            Email = "superuser@mail.com",
            NormalizedEmail = "SUPERUSER@MAIL.COM",
            UserName = "superuser",
            NormalizedUserName = "SUPERUSER",
            FirstName = "Jane",
            LastName = "Doe",
            DateOfBirth = new DateTime(1985, 1, 1),
            SecurityStamp = Guid.NewGuid().ToString("D"),
            PhoneNumber = "0987654321",
            PhoneNumberConfirmed = true
        };
        superUser.PasswordHash = _ph.HashPassword(superUser, "SuperUser@123");

        var hr = new ApplicationUser
        {
            Id = 3,
            Email = "hr@mail.com",
            NormalizedEmail = "HR@MAIL.COM",
            UserName = "hr",
            NormalizedUserName = "HR",
            FirstName = "Alice",
            LastName = "Smith",
            DateOfBirth = new DateTime(1992, 1, 1),
            SecurityStamp = Guid.NewGuid().ToString("D"),
            PhoneNumber = "5551234567",
            PhoneNumberConfirmed = true
        };
        hr.PasswordHash = _ph.HashPassword(hr, "Hr@123");

        var admin = new ApplicationUser
        {
            Id = 4,
            Email = "admin@mail.com",
            NormalizedEmail = "ADMIN@MAIL.COM",
            UserName = "admin",
            NormalizedUserName = "ADMIN",
            FirstName = "Bob",
            LastName = "Johnson",
            DateOfBirth = new DateTime(1980, 1, 1),
            SecurityStamp = Guid.NewGuid().ToString("D"),
            PhoneNumber = "5559876543",
            PhoneNumberConfirmed = true
        };
        admin.PasswordHash = _ph.HashPassword(admin, "Admin@123");

        builder.HasData(user, superUser, hr, admin);
    }
}