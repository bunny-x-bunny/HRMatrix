using HRMatrix.Application.DTOs.WorkExperiences;

namespace HRMatrix.Application.Services.Interfaces
{
    public interface IWorkExperienceService
    {
        Task<List<WorkExperienceResponseDto>> GetWorkExperiencesAsync(int userProfileId);
        Task<int> AddOrUpdateWorkExperienceAsync(CreateWorkExperienceDto workExperienceDto);
        Task<bool> DeleteWorkExperienceAsync(int id);
    }
}
