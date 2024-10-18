using HRMatrix.Application.DTOs.FamilyStatus;
using HRMatrix.Application.DTOs.UserProfileEducation;
using HRMatrix.Application.DTOs.UserProfileSkills;

namespace HRMatrix.Application.DTOs.UserProfile;

public class UserProfileDto : UserProfileBaseDto
{
    public int Id { get; set; }
    public FamilyStatusDto FamilyStatus { get; set; }
    public List<UserProfileEducationResponse> UserEducations { get; set; }

    public List<UserProfileSkillResponse> UserProfileSkills { get; set; }
}