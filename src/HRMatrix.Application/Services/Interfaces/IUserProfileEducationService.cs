using HRMatrix.Application.DTOs.UserProfileEducation;
using HRMatrix.Domain.Entities;

namespace HRMatrix.Application.Services.Interfaces;

public interface IUserProfileEducationService
{
    //Task<UserProfileEducationListResponse> GetUserProfileEducationsAsync(int userProfileId);

    Task<UserProfileEducationResponse> CreateUserProfileEducationAsync(CreateUserProfileEducationRequest educationRequest, bool withSave = false);
    
    Task<UserProfileEducationListResponse?> CreateUserProfileEducationsAsync(List<UserEducationEntryRequest> educationRequests, UserProfile user, bool withSave = false);

    Task<UserProfileEducationListResponse?> UpdateUserProfileEducationsAsync(List<UserEducationEntryRequest> educationRequests, UserProfile user, bool withSave = false);
}
