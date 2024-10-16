namespace HRMatrix.Application.DTOs.UserProfileEducation;

public class CreateUserProfileEducationRequest
{
    public int UserProfileId { get; set; }
    public int EducationLevelId { get; set; }
    public int Quantity { get; set; }
}