namespace HRMatrix.Application.DTOs.WorkType;

public class CreateWorkTypeDto
{
    public string Name { get; set; }
    public List<CreateWorkTypeTranslationDto> Translations { get; set; }
}