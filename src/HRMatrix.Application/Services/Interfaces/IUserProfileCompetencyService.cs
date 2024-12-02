using HRMatrix.Application.DTOs.UserProfileCompetency;
using HRMatrix.Domain.Entities;

namespace HRMatrix.Application.Services.Interfaces;

public interface IUserProfileCompetencyService
{
    //Task<UserProfileCompetencyListResponse> GetUserProfileCompetenciesAsync(int userProfileId);
    Task<int> UpsertUserProfileCompetenciesAsync(List<CreateUserProfileCompetencyRequest> competenciesRequest, UserProfile user, bool withSave = false);
    Task<bool> DeleteUserProfileCompetencyAsync(int id, bool withSave = false);
}