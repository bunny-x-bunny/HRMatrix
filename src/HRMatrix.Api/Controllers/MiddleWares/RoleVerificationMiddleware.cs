using HRMatrix.IdentityService.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace HRMatrix.Api.MiddleWares;

public class RoleVerificationMiddleware
{
    private readonly RequestDelegate _next;

    public RoleVerificationMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context, UserManager<ApplicationUser> userManager)
    {
        if (context.User.Identity?.IsAuthenticated == true)
        {
            var userName = context.User.Identity.Name;
            if (!string.IsNullOrEmpty(userName))
            {
                var user = await userManager.FindByNameAsync(userName);
                if (user != null)
                {
                    var roles = await userManager.GetRolesAsync(user);
                    
                    var roleClaims = roles.Select(role => new Claim(ClaimTypes.Role, role));
                    
                    var identity = new ClaimsIdentity(roleClaims, "CustomRoleVerification");
                    context.User.AddIdentity(identity);
                }
            }
        }

        await _next(context);
    }
}