namespace HRMatrix.Application.DTOs.WorkType;

public class UpdateWorkTypeDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<UpdateWorkTypeTranslationDto> Translations { get; set; }
}