namespace HRMatrix.Domain.Entities;

public class UserProfileLanguage
{
    public int Id { get; set; }
    public int UserProfileId { get; set; }
    public UserProfile UserProfile { get; set; }
    public int LanguageId { get; set; }
    public Language Language { get; set; }
    public int ProficiencyLevel { get; set; }
}
