using HRMatrix.Application.DTOs.FamilyStatus;
using HRMatrix.Application.DTOs.UserProfileWorkType;
using HRMatrix.Domain.Entities;

namespace HRMatrix.Application.Services.Interfaces
{
    public interface IUserProfileWorkTypeService
    {
        Task<List<UserProfileWorkTypeResponse>> GetAllWorkTypesForUserProfileAsync(UserProfile user);
        Task<int> CreateWorkTypeForUserProfileAsync(CreateUserProfileWorkTypeRequest workTypeDto, UserProfile user, bool withSave = false);
        Task<List<int>> UpsertWorkTypesForUserProfileAsync(CreateUserProfileWorkTypesRequest workTypesDto, bool withSave = false);
        Task<bool> DeleteWorkTypeForUserProfileAsync(int userProfileWorkTypeId, bool withSave = false);
    }
}