namespace HRMatrix.Application.DTOs.EducationLevel;

public class UpdateEducationLevelDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<UpdateEducationLevelTranslationDto> Translations { get; set; }
}
