namespace HRMatrix.Domain.Entities;

public class Competency
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<CompetencyTranslation> Translations { get; set; }
}