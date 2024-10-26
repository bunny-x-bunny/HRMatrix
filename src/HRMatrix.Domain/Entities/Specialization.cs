namespace HRMatrix.Domain.Entities;

public class Specialization
{
    public int Id { get; set; }

    public string Name { get; set; }

    public ICollection<Skill> Skills { get; set; }

    public ICollection<SpecializationTranslation> Translations { get; set; }
}