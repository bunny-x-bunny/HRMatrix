using AutoMapper;
using HRMatrix.Application.DTOs.WorkType;
using HRMatrix.Application.Services.Interfaces.Directions;
using HRMatrix.Domain.Entities;
using HRMatrix.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace HRMatrix.Application.Services.Directions;

public class WorkTypeService : IWorkTypeService
{
    private readonly HRMatrixDbContext _context;
    private readonly IMapper _mapper;

    public WorkTypeService(HRMatrixDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<WorkTypeDto>> GetAllWorkTypesAsync()
    {
        var workTypes = await _context.WorkTypes
            .Include(wt => wt.Translations)
            .ToListAsync();
        return _mapper.Map<List<WorkTypeDto>>(workTypes);
    }

    public async Task<WorkTypeDto> GetWorkTypeByIdAsync(int id)
    {
        var workType = await _context.WorkTypes
            .Include(wt => wt.Translations)
            .FirstOrDefaultAsync(wt => wt.Id == id);
        return _mapper.Map<WorkTypeDto>(workType);
    }

    public async Task<int> CreateWorkTypeAsync(CreateWorkTypeDto workTypeDto)
    {
        var workType = _mapper.Map<WorkType>(workTypeDto);

        workType.Translations = workTypeDto.Translations.Select(translation => new WorkTypeTranslation
        {
            Name = translation.Name,
            LanguageCode = translation.LanguageCode
        }).ToList();

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