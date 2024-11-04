namespace HRMatrix.Application.DTOs.Country;

public class UpdateCountryDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<UpdateCountryTranslationDto> Translations { get; set; }
}