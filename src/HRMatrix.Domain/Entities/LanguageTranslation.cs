namespace HRMatrix.Domain.Entities;

public class LanguageTranslation
{
    public int Id { get; set; }
    public int LanguageId { get; set; }
    public Language Language { get; set; }
    public string Name { get; set; }
    public string LanguageCode { get; set; }
}