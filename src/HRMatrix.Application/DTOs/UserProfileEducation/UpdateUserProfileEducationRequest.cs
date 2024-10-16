namespace HRMatrix.Application.DTOs.UserProfileEducation;

public class UpdateUserProfileEducationRequest
{
    public int UserProfileId { get; set; } 
    public List<UserEducationEntryRequest> Educations { get; set; }
}