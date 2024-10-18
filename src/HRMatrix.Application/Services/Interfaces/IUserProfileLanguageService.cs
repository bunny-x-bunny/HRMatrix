using HRMatrix.Application.DTOs.UserProfilesLanguages;

namespace HRMatrix.Application.Services.Interfaces;

public interface IUserProfileLanguageService
{
    Task<UserProfileLanguageListResponse> GetUserProfileLanguagesAsync(int userProfileId);
    Task<int> UpsertUserProfileLanguagesAsync(CreateUserProfileLanguagesRequest languagesRequest);
    Task<bool> DeleteUserProfileLanguageAsync(int id);
}
