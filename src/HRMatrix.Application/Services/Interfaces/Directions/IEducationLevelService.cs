using HRMatrix.Application.DTOs.EducationLevel;

namespace HRMatrix.Application.Services.Interfaces;

public interface IEducationLevelService
{
    Task<List<EducationLevelDto>> GetAllEducationLevelsAsync();
    Task<EducationLevelDto> GetEducationLevelByIdAsync(int id);
    Task<EducationLevelDto> CreateEducationLevelAsync(CreateEducationLevelDto educationLevelDto);
    Task<bool> UpdateEducationLevelAsync(int id, UpdateEducationLevelDto educationLevelDto);
    Task<bool> DeleteEducationLevelAsync(int id);
}