using HRMatrix.Application.DTOs.Languages;

namespace HRMatrix.Application.Services.Interfaces.Directions;

public interface ILanguageService
{
    Task<List<LanguageDto>> GetAllLanguagesAsync();
    Task<LanguageDto> GetLanguageByIdAsync(int id);
    Task<int> CreateLanguageAsync(CreateLanguageDto languageDto);
    Task<int> UpdateLanguageAsync(UpdateLanguageDto languageDto);
    Task<bool> DeleteLanguageAsync(int id);
}
