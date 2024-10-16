using AutoMapper;
using HRMatrix.Application.DTOs.EducationLevel;
using HRMatrix.Application.Services.Interfaces;
using HRMatrix.Domain.Entities;
using HRMatrix.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace HRMatrix.Application.Services;

public class EducationLevelService : IEducationLevelService
{
    private readonly HRMatrixDbContext _context;
    private readonly IMapper _mapper;

    public EducationLevelService(HRMatrixDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<EducationLevelDto>> GetAllEducationLevelsAsync()
    {
        var levels = await _context.EducationLevels
            .Include(e => e.Translations)
            .ToListAsync();
        return _mapper.Map<List<EducationLevelDto>>(levels);
    }

    public async Task<EducationLevelDto> GetEducationLevelByIdAsync(int id)
    {
        var level = await _context.EducationLevels
            .Include(e => e.Translations)
            .FirstOrDefaultAsync(e => e.Id == id);
        return _mapper.Map<EducationLevelDto>(level);
    }

    public async Task<EducationLevelDto> CreateEducationLevelAsync(CreateEducationLevelDto educationLevelDto)
    {
        var level = _mapper.Map<EducationLevel>(educationLevelDto);

        level.Translations = educationLevelDto.Translations.Select(translation => new EducationLevelTranslation
        {
            Name = translation.Name,
            LanguageCode = translation.LanguageCode
        }).ToList();

        _context.EducationLevels.Add(level);
        await _context.SaveChangesAsync();

        return _mapper.Map<EducationLevelDto>(level);
    }

    public async Task<bool> UpdateEducationLevelAsync(int id, UpdateEducationLevelDto educationLevelDto)
    {
        var level = await _context.EducationLevels
            .Include(e => e.Translations)
            .FirstOrDefaultAsync(e => e.Id == id);

        if (level == null) return false;
        
        level.Name = educationLevelDto.Name;
        
        foreach (var translationDto in educationLevelDto.Translations)
        {
            var existingTranslation = level.Translations
                .FirstOrDefault(t => t.LanguageCode == translationDto.LanguageCode);

            if (existingTranslation != null)
            {
                existingTranslation.Name = translationDto.Name;
            }
            else
            {
                var newTranslation = new EducationLevelTranslation
                {
                    Name = translationDto.Name,
                    LanguageCode = translationDto.LanguageCode,
                    EducationLevelId = id
                };
                level.Translations.Add(newTranslation);
            }
        }

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteEducationLevelAsync(int id)
    {
        var level = await _context.EducationLevels.FindAsync(id);
        if (level == null) return false;

        _context.EducationLevels.Remove(level);
        await _context.SaveChangesAsync();
        return true;
    }
}