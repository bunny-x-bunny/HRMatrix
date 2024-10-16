namespace HRMatrix.Application.DTOs.UserProfileEducation;

public class CreateMultipleUserProfileEducationRequest
{
    public int UserProfileId { get; set; }
    public List<UserEducationEntryRequest> Educations { get; set; }
}