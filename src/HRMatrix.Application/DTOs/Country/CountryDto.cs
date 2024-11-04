namespace HRMatrix.Application.DTOs.Country;

public class CountryDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<CountryTranslationDto> Translations { get; set; }
}