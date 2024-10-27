namespace HRMatrix.Domain.Entities;

public class OrderSkill
{
    public int OrderId { get; set; }
    public Order Order { get; set; }

    public int SkillId { get; set; }
    public Skill Skill { get; set; }
}