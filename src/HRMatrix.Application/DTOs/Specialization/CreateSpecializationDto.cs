namespace HRMatrix.Application.DTOs.Specialization;

public class CreateSpecializationDto
{
    public string Name { get; set; }
    public List<CreateSpecializationTranslationDto> Translations { get; set; }
}