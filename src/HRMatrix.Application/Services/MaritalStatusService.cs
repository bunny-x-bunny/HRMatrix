using AutoMapper;
using HRMatrix.Application.DTOs.MaterialStatus;
using HRMatrix.Application.Services.Interfaces;
using HRMatrix.Domain.Entities;
using HRMatrix.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace HRMatrix.Application.Services;

public class MaritalStatusService : IMaritalStatusService
{
    private readonly HRMatrixDbContext _context;
    private readonly IMapper _mapper;

    public MaritalStatusService(HRMatrixDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<MaritalStatusDto>> GetAllMaritalStatusesAsync()
    {
        var statuses = await _context.MaritalStatuses
            .Include(ms => ms.Translations)
            .ToListAsync();

        return _mapper.Map<List<MaritalStatusDto>>(statuses);
    }

    public async Task<MaritalStatusDto> GetMaritalStatusByIdAsync(int id)
    {
        var status = await _context.MaritalStatuses
            .Include(ms => ms.Translations)
            .FirstOrDefaultAsync(ms => ms.Id == id);

        return _mapper.Map<MaritalStatusDto>(status);
    }

    public async Task<MaritalStatusDto> CreateMaritalStatusAsync(MaritalStatusDto maritalStatusDto)
    {
        var status = _mapper.Map<MaritalStatus>(maritalStatusDto);
        _context.MaritalStatuses.Add(status);
        await _context.SaveChangesAsync();

        return _mapper.Map<MaritalStatusDto>(status);
    }

    public async Task<MaritalStatusDto> UpdateMaritalStatusAsync(MaritalStatusDto maritalStatusDto)
    {
        var status = await _context.MaritalStatuses.FindAsync(maritalStatusDto.Id);
        if (status == null)
        {
            return null;
        }

        _mapper.Map(maritalStatusDto, status);
        await _context.SaveChangesAsync();

        return _mapper.Map<MaritalStatusDto>(status);
    }

    public async Task<bool> DeleteMaritalStatusAsync(int id)
    {
        var status = await _context.MaritalStatuses.FindAsync(id);
        if (status == null)
        {
            return false;
        }

        _context.MaritalStatuses.Remove(status);
        await _context.SaveChangesAsync();
        return true;
    }
}