namespace HRMatrix.Domain.Entities;

public class SkillTranslation
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string LanguageCode { get; set; }
    public int SkillId { get; set; }
    public Skill Skill { get; set; }
}
