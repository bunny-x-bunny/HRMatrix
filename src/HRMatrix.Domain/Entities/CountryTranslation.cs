namespace HRMatrix.Domain.Entities;

public class CountryTranslation
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string LanguageCode { get; set; }
    public int CountryId { get; set; }
    public Country Country { get; set; }
}