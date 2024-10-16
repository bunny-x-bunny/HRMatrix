using HRMatrix.Application.DTOs.UserProfile;

namespace HRMatrix.Application.Services.Interfaces;

public interface IUserProfileService
{
    Task<List<UserProfileDto>> GetAllUserProfilesAsync();
    Task<UserProfileDto> GetUserProfileByIdAsync(int id);
    Task<UserProfileDto> CreateUserProfileAsync(CreateUserProfileDto userProfileDto);
    Task<UserProfileDto> UpdateUserProfileAsync(UpdateUserProfileDto userProfileDto);
    Task<bool> DeleteUserProfileAsync(int id);
    Task UpdateProfileDocuments(int profileId, string photoFileName, string videoFileName);
}