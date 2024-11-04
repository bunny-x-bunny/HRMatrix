using HRMatrix.Application.DTOs.Country;

namespace HRMatrix.Application.DTOs.City;

public class CityDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<CityTranslationDto> Translations { get; set; }
    public CountryDto Country { get; set; }
}