namespace HRMatrix.Application.DTOs.City;

public class UpdateCityDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<UpdateCityTranslationDto> Translations { get; set; }
}