namespace HRMatrix.Domain.Entities;

public class UserProfileSkill
{
    public int Id { get; set; }
    public int UserProfileId { get; set; }
    public UserProfile UserProfile { get; set; }
    public int SkillId { get; set; }
    public Skill Skill { get; set; }
    public int ProficiencyLevel { get; set; }
}