using HRMatrix.Application.DTOs.FamilyStatus;
using HRMatrix.Application.DTOs.UserProfileEducation;

namespace HRMatrix.Application.DTOs.UserProfile;

public class UserProfileDto : UserProfileBaseDto
{
    public int Id { get; set; }
    public FamilyStatusDto FamilyStatus { get; set; }
    public List<UserProfileEducationResponse> UserEducations { get; set; }
}