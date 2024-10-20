namespace HRMatrix.Application.DTOs.UserAccount;

public class PatchUserAccountRequest
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public string? Role { get; set; }
}