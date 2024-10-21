namespace HRMatrix.Application.DTOs.Competency;

public class UpdateCompetencyDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<UpdateCompetencyTranslationDto> Translations { get; set; }
}