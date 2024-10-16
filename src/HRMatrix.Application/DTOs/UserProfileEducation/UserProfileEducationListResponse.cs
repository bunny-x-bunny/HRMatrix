namespace HRMatrix.Application.DTOs.UserProfileEducation;

public class UserProfileEducationListResponse
{
    public int UserProfileId { get; set; } 
    public List<UserProfileEducationResponse> Educations { get; set; }
}