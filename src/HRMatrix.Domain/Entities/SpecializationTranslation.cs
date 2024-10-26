namespace HRMatrix.Domain.Entities;

public class SpecializationTranslation
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string LanguageCode { get; set; }

    public int SpecializationId { get; set; }
    public Specialization Specialization { get; set; }
}