using HRMatrix.Application.DTOs.Languages;

namespace HRMatrix.Application.DTOs.UserProfilesLanguages;

public class UserProfileLanguageResponse
{
    public int LanguageId { get; set; }
    public string LanguageName { get; set; }
    public List<LanguageTranslationDto> Translations { get; set; }
    public int ProficiencyLevel { get; set; }
}
