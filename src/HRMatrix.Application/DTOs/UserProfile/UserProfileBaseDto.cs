namespace HRMatrix.Application.DTOs.UserProfile;

public class UserProfileBaseDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string AdditionalSkills { get; set; }
    public string AdditionalCompetences { get; set; }
    public string ProfilePhotoPath { get; set; }
    public string VideoPath { get; set; }
}