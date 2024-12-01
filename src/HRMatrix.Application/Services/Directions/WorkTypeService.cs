using HRMatrix.Application.DTOs.WorkType;
using HRMatrix.Application.Services.Interfaces.Directions;
using HRMatrix.Domain.Entities;
using HRMatrix.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace HRMatrix.Application.Services.Directions;

public class WorkTypeService : IWorkTypeService
{
    private readonly HRMatrixDbContext _context;

    public WorkTypeService(HRMatrixDbContext context)
    {
        _context = context;
    }

    public async Task<List<WorkTypeDto>> GetAllWorkTypesAsync()
    {
        var workTypes = await _context.WorkTypes
            .Include(wt => wt.Translations)
            .ToListAsync();
        return workTypes.Select(wt => new WorkTypeDto {
            Id = wt.Id,
            Name = wt.Name,
            Translations = wt.Translations.Select(t => new WorkTypeTranslationDto {
                Id = t.Id,
                Name = t.Name,
                LanguageCode = t.LanguageCode
            }).ToList()
        }).ToList();
    }

    public async Task<WorkTypeDto> GetWorkTypeByIdAsync(int id)
    {
        var workType = await _context.WorkTypes
            .Include(wt => wt.Translations)
            .FirstOrDefaultAsync(wt => wt.Id == id);
        if (workType == null)
            throw new Exception("WorkType not found");

        return new WorkTypeDto {
            Id = workType.Id,
            Name = workType.Name,
            Translations = workType.Translations.Select(t => new WorkTypeTranslationDto {
                Id = t.Id,
                Name = t.Name,
                LanguageCode = t.LanguageCode
            }).ToList()
        };
    }

    public async Task<int> CreateWorkTypeAsync(CreateWorkTypeDto workTypeDto)
    {
        var workType = new WorkType {
            Name = workTypeDto.Name,
            Translations = workTypeDto.Translations.Select(translation => new WorkTypeTranslation {
                Name = translation.Name,
                LanguageCode = translation.LanguageCode
            }).ToList()
        };

        _context.WorkTypes.Add(workType);
        await _context.SaveChangesAsync();

        return workType.Id;
    }

    public async Task<int> UpdateWorkTypeAsync(UpdateWorkTypeDto workTypeDto)
    {
        var workType = await _context.WorkTypes
            .Include(wt => wt.Translations)
            .FirstOrDefaultAsync(wt => wt.Id == workTypeDto.Id);

        if (workType == null) return 0;

        workType.Name = workTypeDto.Name;

        foreach (var translationDto in workTypeDto.Translations)
        {
            var existingTranslation = workType.Translations
                .FirstOrDefault(t => t.LanguageCode == translationDto.LanguageCode);

            if (existingTranslation != null)
            {
                existingTranslation.Name = translationDto.Name;
            }
            else
            {
                var newTranslation = new WorkTypeTranslation
                {
                    Name = translationDto.Name,
                    LanguageCode = translationDto.LanguageCode,
                    WorkTypeId = workType.Id
                };
                workType.Translations.Add(newTranslation);
            }
        }

        await _context.SaveChangesAsync();
        return workType.Id;
    }

    public async Task<bool> DeleteWorkTypeAsync(int id)
    {
        var workType = await _context.WorkTypes.FindAsync(id);
        if (workType == null) return false;

        _context.WorkTypes.Remove(workType);
        await _context.SaveChangesAsync();
        return true;
    }
}