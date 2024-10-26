namespace HRMatrix.Application.DTOs.Specialization;

public class UpdateSpecializationDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<UpdateSpecializationTranslationDto> Translations { get; set; }
}