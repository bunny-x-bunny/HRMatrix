using HRMatrix.Application.DTOs.FamilyStatus;
using HRMatrix.Application.DTOs.UserProfileEducation;

namespace HRMatrix.Application.DTOs.UserProfile;

public class UpdateUserProfileDto : UserProfileBaseDto
{
    public int Id { get; set; }
    public UpdateFamilyStatusDto FamilyStatus { get; set; }
    public List<UserEducationEntryRequest> UserEducations { get; set; }
}