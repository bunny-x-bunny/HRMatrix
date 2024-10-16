namespace HRMatrix.Application.DTOs.Skill;

public class UpdateSkillDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<UpdateSkillTranslationDto> Translations { get; set; }
}