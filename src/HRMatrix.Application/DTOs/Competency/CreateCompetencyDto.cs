namespace HRMatrix.Application.DTOs.Competency;

public class CreateCompetencyDto
{
    public string Name { get; set; }
    public List<CreateCompetencyTranslationDto> Translations { get; set; }
}