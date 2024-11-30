using HRMatrix.Application.DTOs.FamilyStatus;
using HRMatrix.Domain.Entities;

namespace HRMatrix.Application.Services.Interfaces;

public interface IUserProfileFamilyStatusService {
    //Task<List<UpdateFamilyStatusDto>> GetAllFamilyStatusesForUserProfileAsync(int userProfileId);
    Task<int> CreateFamilyStatusForUserProfileAsync(CreateFamilyStatusDto familyStatusDto, UserProfile user, bool withSave = false);
    Task<bool> UpdateFamilyStatusForUserProfileAsync(UpdateFamilyStatusDto familyStatusDto, UserProfile user);
    Task<bool> DeleteFamilyStatusForUserProfileAsync(UserProfile user);
}