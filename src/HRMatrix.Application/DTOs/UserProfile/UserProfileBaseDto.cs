namespace HRMatrix.Application.DTOs.UserProfile;

public class UserProfileBaseDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public decimal? Iq { get; set; }
    public decimal? Eq { get; set; }
}