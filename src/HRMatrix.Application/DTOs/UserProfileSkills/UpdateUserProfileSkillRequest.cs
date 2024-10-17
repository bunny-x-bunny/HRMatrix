namespace HRMatrix.Application.DTOs.UserProfileSkills;

public class UpdateUserProfileSkillRequest
{
    public int Id { get; set; }
    public int SkillId { get; set; }
    public int ProficiencyLevel { get; set; }
}