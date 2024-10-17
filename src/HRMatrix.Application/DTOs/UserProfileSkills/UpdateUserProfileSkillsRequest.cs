namespace HRMatrix.Application.DTOs.UserProfileSkills;

public class UpdateUserProfileSkillsRequest
{
    public int UserProfileId { get; set; }
    public List<UpdateUserProfileSkillRequest> Skills { get; set; }
}