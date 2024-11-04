namespace HRMatrix.Domain.Entities;

public class UserProfileWorkType
{
    public int Id { get; set; }
    public int UserProfileId { get; set; }
    public UserProfile UserProfile { get; set; }
    public int WorkTypeId { get; set; }
    public WorkType WorkType { get; set; }
}