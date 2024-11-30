using HRMatrix.Application.DTOs.UserProfileEducation;
using HRMatrix.Domain.Entities;

namespace HRMatrix.Application.Services.Interfaces;

public interface IUserProfileEducationService
{
    Task<UserProfileEducationListResponse> GetUserProfileEducationsAsync(int userProfileId);

    Task<UserProfileEducationResponse> CreateUserProfileEducationAsync(CreateUserProfileEducationRequest educationRequest, bool withSave = false);
    
    Task<UserProfileEducationListResponse?> CreateUserProfileEducationsAsync(int userProfileId, List<UserEducationEntryRequest> educationRequests, bool withSave = false);

    Task<UserProfileEducationListResponse?> UpdateUserProfileEducationsAsync(UpdateUserProfileEducationRequest updateRequest, bool withSave = false);
}
