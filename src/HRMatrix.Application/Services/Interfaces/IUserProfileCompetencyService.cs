using HRMatrix.Application.DTOs.UserProfileCompetency;

namespace HRMatrix.Application.Services.Interfaces;

public interface IUserProfileCompetencyService
{
    Task<UserProfileCompetencyListResponse> GetUserProfileCompetenciesAsync(int userProfileId);
    Task<int> UpsertUserProfileCompetenciesAsync(CreateUserProfileCompetenciesRequest competenciesRequest);
    Task<bool> DeleteUserProfileCompetencyAsync(int id);
}