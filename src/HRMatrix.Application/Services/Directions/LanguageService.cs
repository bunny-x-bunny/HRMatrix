using AutoMapper;
using HRMatrix.Application.DTOs.Languages;
using HRMatrix.Application.Services.Interfaces.Directions;
using HRMatrix.Domain.Entities;
using HRMatrix.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace HRMatrix.Application.Services.Directions;

public class LanguageService : ILanguageService
{
    private readonly HRMatrixDbContext _context;
    private readonly IMapper _mapper;

    public LanguageService(HRMatrixDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<LanguageDto>> GetAllLanguagesAsync()
    {
        var languages = await _context.Languages
            .Include(l => l.Translations)
            .ToListAsync();
        return _mapper.Map<List<LanguageDto>>(languages);
    }

    public async Task<LanguageDto> GetLanguageByIdAsync(int id)
    {
        var language = await _context.Languages
            .Include(l => l.Translations)
            .FirstOrDefaultAsync(l => l.Id == id);
        return _mapper.Map<LanguageDto>(language);
    }

    public async Task<int> CreateLanguageAsync(CreateLanguageDto languageDto)
    {
        var language = _mapper.Map<Language>(languageDto);

        language.Translations = languageDto.Translations.Select(translation => new LanguageTranslation
        {
            Name = translation.Name,
            LanguageCode = translation.LanguageCode
        }).ToList();

        _context.Languages.Add(language);
        await _context.SaveChangesAsync();

        return language.Id;
    }

    public async Task<int> UpdateLanguageAsync(UpdateLanguageDto languageDto)
    {
        var language = await _context.Languages
            .Include(l => l.Translations)
            .FirstOrDefaultAsync(l => l.Id == languageDto.Id);

        if (language == null) return 0;

        language.Name = languageDto.Name;

        foreach (var translationDto in languageDto.Translations)
        {
            var existingTranslation = language.Translations
                .FirstOrDefault(t => t.LanguageCode == translationDto.LanguageCode);

            if (existingTranslation != null)
            {
                existingTranslation.Name = translationDto.Name;
            }
            else
            {
                var newTranslation = new LanguageTranslation
                {
                    Name = translationDto.Name,
                    LanguageCode = translationDto.LanguageCode,
                    LanguageId = language.Id
                };
                language.Translations.Add(newTranslation);
            }
        }

        await _context.SaveChangesAsync();
        return language.Id;
    }

    public async Task<bool> DeleteLanguageAsync(int id)
    {
        var language = await _context.Languages.FindAsync(id);
        if (language == null) return false;

        _context.Languages.Remove(language);
        await _context.SaveChangesAsync();
        return true;
    }
}
