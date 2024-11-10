using HRMatrix.Application.DTOs.UserProfile;
using System.Threading.Tasks;
using HRMatrix.Application.DTOs.Common;

namespace HRMatrix.Application.Services.Interfaces;

public interface IUserProfileService
{
    Task<List<UserProfileDto>> GetAllUserProfilesAsync();
    Task<UserProfileDto> GetUserProfileByIdAsync(int id);
    Task<int> CreateUserProfileAsync(CreateUserProfileDto userProfileDto, int userId);
    Task<UserProfileDto> UpdateUserProfileAsync(UpdateUserProfileDto userProfileDto, int userId);
    Task<bool> DeleteUserProfileAsync(int id);
    Task UpdateProfileDocuments(int profileId, string photoFileName, string videoFileName);

    Task<PaginatedResult<UserProfileSuggestionDto>> SearchUserProfilesAsync(
        string query = null,
        int limit = 10,
        List<int> categoryIds = null,
        List<int> specialtyIds = null,
        List<int> locationIds = null,
        List<int> workTypeIds = null,
        int page = 1,
        int pageSize = 10);
    Task<List<UserProfileDto>> GetUserProfileByAspNetUserId(int id);
}