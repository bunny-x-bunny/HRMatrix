namespace HRMatrix.Domain.Entities;

public class UserProfileEducation
{
    public int Id { get; set; }
    public int UserProfileId { get; set; }
    public UserProfile UserProfile { get; set; }
    public int EducationLevelId { get; set; }
    public EducationLevel EducationLevel { get; set; }
    public int Quantity { get; set; }
}