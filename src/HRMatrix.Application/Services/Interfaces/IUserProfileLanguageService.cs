using HRMatrix.Application.DTOs.UserProfilesLanguages;
using HRMatrix.Domain.Entities;

namespace HRMatrix.Application.Services.Interfaces;

public interface IUserProfileLanguageService
{
    Task<UserProfileLanguageListResponse> GetUserProfileLanguagesAsync(int userProfileId);
    Task<int> CreateUserProfileLanguagesAsync(List<CreateUserProfileLanguageRequest> languagesRequest, UserProfile user, bool withSave = false);
    Task<int> UpdateUserProfileLanguagesAsync(List<CreateUserProfileLanguageRequest> languagesRequest, UserProfile user, bool withSave = false);
    Task<bool> DeleteUserProfileLanguageAsync(int id);
}
