using HRMatrix.Application.DTOs.UserProfile;
using System.Threading.Tasks;

namespace HRMatrix.Application.Services.Interfaces;

public interface IUserProfileService
{
    Task<List<UserProfileDto>> GetAllUserProfilesAsync();
    Task<UserProfileDto> GetUserProfileByIdAsync(int id);
    Task<int> CreateUserProfileAsync(CreateUserProfileDto userProfileDto, int userId);
    Task<UserProfileDto> UpdateUserProfileAsync(UpdateUserProfileDto userProfileDto, int userId);
    Task<bool> DeleteUserProfileAsync(int id);
    Task UpdateProfileDocuments(int profileId, string photoFileName, string videoFileName);
    Task<List<UserProfileSuggestionDto>> SearchUserProfilesAsync(string query, int limit, int? categoryId, int? specialtyId, int? locationId, int? workTypeId);
    Task<List<UserProfileDto>> GetUserProfileByAspNetUserId(int id);
}