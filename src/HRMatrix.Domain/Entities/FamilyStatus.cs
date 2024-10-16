namespace HRMatrix.Domain.Entities;

public class FamilyStatus
{
    public int Id { get; set; }
    public int UserProfileId { get; set; }
    public UserProfile UserProfile { get; set; }
    public int MaritalStatusId { get; set; }
    public MaritalStatus MaritalStatus { get; set; }
    public int TimesMarried { get; set; }
    public string MarriagePeriods { get; set; }
    public int NumberOfChildren { get; set; }
}