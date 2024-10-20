namespace HRMatrix.Application.DTOs.UserAccount;

public class UpdateUserAccountRequest
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
}