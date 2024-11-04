namespace HRMatrix.Application.DTOs.UserProfilesLanguages;

public class UserProfileLanguageListResponse
{
    public int UserProfileId { get; set; }
    public List<UserProfileLanguageResponse> Languages { get; set; }
}