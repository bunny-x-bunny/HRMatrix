using HRMatrix.Application.DTOs.FamilyStatus;
using HRMatrix.Application.DTOs.UserProfileEducation;

namespace HRMatrix.Application.DTOs.UserProfile;

public class CreateUserProfileDto : UserProfileBaseDto
{
    public CreateFamilyStatusDto FamilyStatus { get; set; }
    public List<UserEducationEntryRequest> UserEducations { get; set; }
}