namespace HRMatrix.Application.DTOs.EducationLevel;

public class EducationLevelDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<EducationLevelTranslationDto> Translations { get; set; }
}