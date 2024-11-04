namespace HRMatrix.Application.DTOs.UserProfilesLanguages;

public class CreateUserProfileLanguagesRequest
{
    public int UserProfileId { get; set; }
    public List<CreateUserProfileLanguageRequest> Languages { get; set; }
}