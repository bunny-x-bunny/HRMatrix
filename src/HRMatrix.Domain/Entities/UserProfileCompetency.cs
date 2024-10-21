namespace HRMatrix.Domain.Entities;

public class UserProfileCompetency
{
    public int Id { get; set; }
    public int UserProfileId { get; set; }
    public UserProfile UserProfile { get; set; }
    public int CompetencyId { get; set; }
    public Competency Competency { get; set; }
    public int ProficiencyLevel { get; set; }
}