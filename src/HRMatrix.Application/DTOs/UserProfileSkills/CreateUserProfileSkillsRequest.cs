namespace HRMatrix.Application.DTOs.UserProfileSkills;

public class CreateUserProfileSkillsRequest
{
    public int UserProfileId { get; set; }
    public List<CreateUserProfileSkillRequest> Skills { get; set; }
}