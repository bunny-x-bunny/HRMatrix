namespace HRMatrix.Application.DTOs.Skill;

public class CreateSkillDto
{
    public string Name { get; set; }
    public List<CreateSkillTranslationDto> Translations { get; set; }
}