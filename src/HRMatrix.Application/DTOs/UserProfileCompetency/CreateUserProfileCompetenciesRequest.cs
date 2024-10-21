namespace HRMatrix.Application.DTOs.UserProfileCompetency;

public class CreateUserProfileCompetenciesRequest
{
    public int UserProfileId { get; set; }
    public List<CreateUserProfileCompetencyRequest> Competencies { get; set; }
}