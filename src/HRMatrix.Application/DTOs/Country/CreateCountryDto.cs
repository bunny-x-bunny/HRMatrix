using HRMatrix.Application.DTOs.Country;

namespace HRMatrix.Application.DTOs;

public class CreateCountryDto
{
    public string Name { get; set; }
    public List<CreateCountryTranslationDto> Translations { get; set; }
}