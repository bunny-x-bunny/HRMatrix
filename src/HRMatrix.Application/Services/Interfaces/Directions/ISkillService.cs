using HRMatrix.Application.DTOs.Skill;

namespace HRMatrix.Application.Services.Interfaces.Directions;

public interface ISkillService
{
    Task<List<SkillDto>> GetAllSkillsAsync();
    Task<SkillDto> GetSkillByIdAsync(int id);
    Task<int> CreateSkillAsync(CreateSkillDto skillDto);
    Task<int> UpdateSkillAsync(UpdateSkillDto skillDto);
    Task<bool> DeleteSkillAsync(int id);
}