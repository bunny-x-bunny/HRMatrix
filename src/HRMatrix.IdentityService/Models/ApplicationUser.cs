using Microsoft.AspNetCore.Identity;

namespace HRMatrix.IdentityService.Models;

public class ApplicationUser : IdentityUser<int>
{
    public string? FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
}
