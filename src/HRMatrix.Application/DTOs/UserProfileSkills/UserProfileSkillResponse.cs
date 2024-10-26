using HRMatrix.Application.DTOs.Skill;
using HRMatrix.Application.DTOs.Specialization;

namespace HRMatrix.Application.DTOs.UserProfileSkills;

public class UserProfileSkillResponse
{
    public int SkillId { get; set; }
    public string SkillName { get; set; }
    public List<SkillTranslationDto> Translations { get; set; }
    public int ProficiencyLevel { get; set; }
    public SpecializationDto Specialization { get; set; }
}