namespace HRMatrix.Application.DTOs.WorkType;

public class WorkTypeDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<WorkTypeTranslationDto> Translations { get; set; }
}