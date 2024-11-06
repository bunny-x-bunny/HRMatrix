using HRMatrix.Application.DTOs.City;
using HRMatrix.Application.DTOs.UserProfileSkills;

namespace HRMatrix.Application.DTOs.UserProfile;

public class UserProfileSuggestionDto
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public List<UserProfileSkillResponse> UserProfileSkills { get; set; }
    public CityDto City { get; set; }
}