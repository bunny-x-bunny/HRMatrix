using HRMatrix.Application.DTOs.FamilyStatus;
using HRMatrix.Application.DTOs.UserProfileWorkType;
using HRMatrix.Domain.Entities;

namespace HRMatrix.Application.Services.Interfaces
{
    public interface IUserProfileWorkTypeService
    {
        //Task<List<UserProfileWorkTypeResponse>> GetUserProfileWorkTypes(UserProfile user);
        Task<int> CreateUserProfileWorkType(CreateUserProfileWorkTypeRequest workTypeDto, UserProfile user, bool withSave = false);
        Task<List<int>> UpsertUserProfileWorkTypes(List<CreateUserProfileWorkTypeRequest> workTypesDto, UserProfile user, bool withSave = false);
        Task<bool> DeleteUserProfileWorkType(int userProfileWorkTypeId, bool withSave = false);
    }
}