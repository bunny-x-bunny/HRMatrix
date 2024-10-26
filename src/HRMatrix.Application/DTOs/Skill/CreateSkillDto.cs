namespace HRMatrix.Application.DTOs.Skill;

public class CreateSkillDto
{
    public string Name { get; set; }
    public int SpecializationId { get; set; }
    public List<CreateSkillTranslationDto> Translations { get; set; }
}