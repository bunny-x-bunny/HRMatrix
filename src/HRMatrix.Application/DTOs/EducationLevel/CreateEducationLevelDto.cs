namespace HRMatrix.Application.DTOs.EducationLevel;

public class CreateEducationLevelDto
{
    public string Name { get; set; }
    public List<CreateEducationLevelTranslationDto> Translations { get; set; }
}