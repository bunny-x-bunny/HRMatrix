using HRMatrix.Application.DTOs.UserProfileEducation;

namespace HRMatrix.Application.Services.Interfaces;

public interface IUserProfileEducationService
{
    Task<UserProfileEducationListResponse> GetUserProfileEducationsAsync(int userProfileId);

    Task<UserProfileEducationResponse> CreateUserProfileEducationAsync(CreateUserProfileEducationRequest educationRequest);
    
    Task<UserProfileEducationListResponse> CreateUserProfileEducationsAsync(int userProfileId, List<UserEducationEntryRequest> educationRequests);

    Task<UserProfileEducationListResponse> UpdateUserProfileEducationsAsync(UpdateUserProfileEducationRequest updateRequest);
}
