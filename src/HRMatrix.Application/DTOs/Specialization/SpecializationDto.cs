namespace HRMatrix.Application.DTOs.Specialization;

public class SpecializationDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<SpecializationTranslationDto> Translations { get; set; }
}