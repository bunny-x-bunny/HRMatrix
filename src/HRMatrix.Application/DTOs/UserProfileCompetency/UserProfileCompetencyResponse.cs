using HRMatrix.Application.DTOs.Competency;

namespace HRMatrix.Application.DTOs.UserProfileCompetency;

public class UserProfileCompetencyResponse
{
    public int CompetencyId { get; set; }
    public string CompetencyName { get; set; }
    public List<CompetencyTranslationDto> Translations { get; set; }
    public int ProficiencyLevel { get; set; }
}