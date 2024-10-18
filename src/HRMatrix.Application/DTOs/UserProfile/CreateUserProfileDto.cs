using HRMatrix.Application.DTOs.FamilyStatus;
using HRMatrix.Application.DTOs.UserProfileEducation;
using HRMatrix.Application.DTOs.UserProfileSkills;

namespace HRMatrix.Application.DTOs.UserProfile;

public class CreateUserProfileDto : UserProfileBaseDto
{
    public CreateFamilyStatusDto FamilyStatus { get; set; }

    public List<UserEducationEntryRequest> UserEducations { get; set; }

    public List<CreateUserProfileSkillRequest> UserProfileSkills { get; set; }
}