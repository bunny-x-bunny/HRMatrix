using HRMatrix.Application.DTOs.FamilyStatus;
using HRMatrix.Application.DTOs.UserProfileCompetency;
using HRMatrix.Application.DTOs.UserProfileEducation;
using HRMatrix.Application.DTOs.UserProfileSkills;
using HRMatrix.Application.DTOs.UserProfilesLanguages;
using HRMatrix.Application.DTOs.WorkExperiences;

namespace HRMatrix.Application.DTOs.UserProfile;

public class CreateUserProfileDto : UserProfileBaseDto
{
    public CreateFamilyStatusDto FamilyStatus { get; set; }
    public int CityId { get; set; }
    public List<UserEducationEntryRequest> UserEducations { get; set; }
    public List<CreateUserProfileSkillRequest> UserProfileSkills { get; set; }
    public List<CreateWorkExperienceNoIdDto> WorkExperiences { get; set; }
    public List<CreateUserProfileLanguageRequest> Languages { get; set; }
    public List<CreateUserProfileCompetencyRequest> Competencies { get; set; }
}