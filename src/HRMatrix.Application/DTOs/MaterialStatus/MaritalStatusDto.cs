namespace HRMatrix.Application.DTOs.MaterialStatus;

public class MaritalStatusDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<MaritalStatusTranslationDto> Translations { get; set; }
}