namespace HRMatrix.Application.DTOs.Skill;

public class SkillDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<SkillTranslationDto> Translations { get; set; }
}