namespace HRMatrix.Application.DTOs.UserProfileCompetency;

public class UserProfileCompetencyListResponse
{
    public int UserProfileId { get; set; }
    public List<UserProfileCompetencyResponse> Competencies { get; set; }
}