using HRMatrix.Application.DTOs.FamilyStatus;
using HRMatrix.Application.DTOs.UserProfileEducation;
using HRMatrix.Application.DTOs.UserProfileSkills;
using HRMatrix.Application.DTOs.UserProfilesLanguages;
using HRMatrix.Application.DTOs.WorkExperiences;

namespace HRMatrix.Application.DTOs.UserProfile;

public class UserProfileDto : UserProfileBaseDto
{
    public int Id { get; set; }
    public FamilyStatusDto FamilyStatus { get; set; }
    public List<UserProfileEducationResponse> UserEducations { get; set; }
    public List<UserProfileSkillResponse> UserProfileSkills { get; set; }
    public List<WorkExperienceResponseDto> WorkExperiences { get; set; }
    public List<UserProfileLanguageResponse> Languages { get; set; }
}