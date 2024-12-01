using HRMatrix.Application.DTOs.UserProfileCompetency;

namespace HRMatrix.Application.Services.Interfaces;

public interface IUserProfileCompetencyService
{
    //Task<UserProfileCompetencyListResponse> GetUserProfileCompetenciesAsync(int userProfileId);
    Task<int> UpsertUserProfileCompetenciesAsync(CreateUserProfileCompetenciesRequest competenciesRequest, bool withSave = false);
    Task<bool> DeleteUserProfileCompetencyAsync(int id, bool withSave = false);
}