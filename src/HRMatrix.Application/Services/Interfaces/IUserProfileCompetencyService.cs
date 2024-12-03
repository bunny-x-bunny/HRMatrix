using HRMatrix.Application.DTOs.UserProfileCompetency;
using HRMatrix.Domain.Entities;

namespace HRMatrix.Application.Services.Interfaces;

public interface IUserProfileCompetencyService
{
    //Task<UserProfileCompetencyListResponse> GetUserProfileCompetenciesAsync(int userProfileId);
    Task<int> CreateUserProfileCompetencies(List<CreateUserProfileCompetencyRequest> competenciesRequest, UserProfile user, bool withSave = false);
    Task<int> UpdateUserProfileCompetencies(List<CreateUserProfileCompetencyRequest> competenciesRequest, UserProfile user, bool withSave = false);
    Task<bool> DeleteUserProfileCompetency(int id, bool withSave = false);
}