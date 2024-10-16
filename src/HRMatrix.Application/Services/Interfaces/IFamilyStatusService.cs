using HRMatrix.Application.DTOs.FamilyStatus;

namespace HRMatrix.Application.Services.Interfaces;

public interface IFamilyStatusService
{
    Task<List<UpdateFamilyStatusDto>> GetAllFamilyStatusesForUserProfileAsync(int userProfileId);
    Task<UpdateFamilyStatusDto> GetFamilyStatusForUserProfileByIdAsync(int id, int userProfileId);
    Task<UpdateFamilyStatusDto> CreateFamilyStatusForUserProfileAsync(CreateFamilyStatusDto familyStatusDto, int userProfileId);
    Task<UpdateFamilyStatusDto> UpdateFamilyStatusForUserProfileAsync(UpdateFamilyStatusDto familyStatusDto, int userProfileId);
    Task<bool> DeleteFamilyStatusForUserProfileAsync(int id, int userProfileId);
}