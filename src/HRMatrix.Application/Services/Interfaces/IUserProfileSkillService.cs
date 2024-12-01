using HRMatrix.Application.DTOs.UserProfileSkills;

namespace HRMatrix.Application.Services;

public interface IUserProfileSkillService
{
    Task<UserProfileSkillListResponse> GetUserProfileSkillsAsync(int userProfileId);
    Task<int> UpsertUserProfileSkillsAsync(CreateUserProfileSkillsRequest skillsRequest, bool withSave = false);
    Task<bool> DeleteUserProfileSkillAsync(int id, bool withSave = false);
}