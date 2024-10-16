using HRMatrix.Application.DTOs.EducationLevel;

namespace HRMatrix.Application.DTOs.UserProfileEducation;

public class UserProfileEducationResponse
{
    public int EducationLevelId { get; set; }
    public string EducationLevelName { get; set; }
    public int Quantity { get; set; }
    public List<EducationLevelTranslationDto> Translations { get; set; }
}