namespace HRMatrix.Domain.Entities;

public class MaritalStatus
{
    public int Id { get; set; }
    public string Name { get; set; }

    public ICollection<FamilyStatus> FamilyStatuses { get; set; }
    public ICollection<MaritalStatusTranslation> Translations { get; set; }
}