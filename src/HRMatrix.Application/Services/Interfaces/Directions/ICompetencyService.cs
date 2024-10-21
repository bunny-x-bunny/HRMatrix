using HRMatrix.Application.DTOs.Competency;

namespace HRMatrix.Application.Services.Interfaces.Directions;

public interface ICompetencyService
{
    Task<List<CompetencyDto>> GetAllCompetenciesAsync();
    Task<CompetencyDto> GetCompetencyByIdAsync(int id);
    Task<int> CreateCompetencyAsync(CreateCompetencyDto competencyDto);
    Task<int> UpdateCompetencyAsync(UpdateCompetencyDto competencyDto);
    Task<bool> DeleteCompetencyAsync(int id);
}