using HRMatrix.Application.DTOs.UserProfileSkills;
using HRMatrix.Domain.Entities;

namespace HRMatrix.Application.Services;

public interface IUserProfileSkillService
{
    //Task<UserProfileSkillListResponse> GetUserProfileSkillsAsync(int userProfileId);
    Task<int> CreateUserProfileSkillsAsync(List<CreateUserProfileSkillRequest> skillsRequest, UserProfile user, bool withSave = false);
    Task<int> UpdateUserProfileSkillsAsync(List<CreateUserProfileSkillRequest> skillsRequest, UserProfile user, bool withSave = false);
    Task<bool> DeleteUserProfileSkillAsync(int id, bool withSave = false);
}