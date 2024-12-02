using HRMatrix.Application.DTOs.WorkExperiences;
using HRMatrix.Domain.Entities;

namespace HRMatrix.Application.Services.Interfaces
{
    public interface IUserProfileWorkExperienceService
    {
        //Task<List<WorkExperienceResponseDto>> GetWorkExperiencesAsync(int userProfileId);
        Task<int> AddOrUpdateWorkExperienceAsync(CreateWorkExperienceDto workExperienceDto, bool withSave = false);
        Task<int> UpsertWorkExperiencesAsync(List<CreateWorkExperienceNoIdDto> workExperiencesDto, UserProfile user, bool withSave = false);
        Task<bool> DeleteWorkExperienceAsync(int id, bool withSave = false);
    }
}
