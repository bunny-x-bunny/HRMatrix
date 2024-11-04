namespace HRMatrix.Application.DTOs.City;

public class CreateCityDto
{
    public string Name { get; set; }
    public int CountryId { get; set; }
    public List<CreateCityTranslationDto> Translations { get; set; }
}