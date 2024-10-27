namespace HRMatrix.Domain.Entities;

public class WorkType
{
    public int Id { get; set; }
    public string Name { get; set; }

    public ICollection<WorkTypeTranslation> Translations { get; set; }
}