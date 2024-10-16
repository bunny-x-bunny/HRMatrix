using HRMatrix.IdentityService.Models;
using HRMatrix.Persistence.Contexts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HRMatrix.Persistence;

public static class AddServices
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("HRMatrixDatabase");

        services.AddDbContext<HRMatrixDbContext>(options =>
            options.UseSqlServer(connectionString,
                builder => builder.MigrationsAssembly(typeof(HRMatrixDbContext).Assembly.FullName)
                    .EnableRetryOnFailure(10)));

        services
            .AddIdentity<ApplicationUser, ApplicationRole>()
            .AddUserManager<UserManager<ApplicationUser>>()
            .AddSignInManager<SignInManager<ApplicationUser>>()
            .AddRoleManager<RoleManager<ApplicationRole>>()
            .AddEntityFrameworkStores<HRMatrixDbContext>()
            .AddDefaultTokenProviders();

        return services;
    }
}
