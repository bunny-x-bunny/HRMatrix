namespace HRMatrix.Domain.Entities;

public class EducationLevel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<EducationLevelTranslation> Translations { get; set; }
}