namespace HRMatrix.Application.DTOs.UserProfileSkills;

public class UserProfileSkillListResponse
{
    public int UserProfileId { get; set; }
    public List<UserProfileSkillResponse> Skills { get; set; }
}