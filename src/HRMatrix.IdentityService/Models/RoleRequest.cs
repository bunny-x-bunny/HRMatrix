namespace HRMatrix.IdentityService.Models;

public class RoleRequest
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public ApplicationUser User { get; set; }
    public string RoleName { get; set; }
    public DateTime RequestedAt { get; set; }
    public string Status { get; set; } = "Pending";
    public DateTime? ApprovedAt { get; set; }
}