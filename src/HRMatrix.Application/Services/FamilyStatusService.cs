using AutoMapper;
using HRMatrix.Application.DTOs.FamilyStatus;
using HRMatrix.Application.Services.Interfaces;
using HRMatrix.Domain.Entities;
using HRMatrix.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace HRMatrix.Application.Services;

public class FamilyStatusService// : IFamilyStatusService
{
    //private readonly HRMatrixDbContext _context;
    //private readonly IMapper _mapper;

    //public FamilyStatusService(HRMatrixDbContext context, IMapper mapper)
    //{
    //    _context = context;
    //    _mapper = mapper;
    //}

    //public async Task<List<UpdateFamilyStatusDto>> GetAllFamilyStatusesForUserProfileAsync(int userProfileId)
    //{
    //    var statuses = await _context.FamilyStatuses
    //        .Include(fs => fs.MaritalStatus)
    //        .Where(fs => fs.UserProfileId == userProfileId)
    //        .ToListAsync();

    //    return _mapper.Map<List<UpdateFamilyStatusDto>>(statuses);
    //}

    //public async Task<UpdateFamilyStatusDto> GetFamilyStatusForUserProfileByIdAsync(int id, int userProfileId)
    //{
    //    var status = await _context.FamilyStatuses
    //        .Include(fs => fs.MaritalStatus)
    //        .FirstOrDefaultAsync(fs => fs.Id == id && fs.UserProfileId == userProfileId);

    //    return _mapper.Map<UpdateFamilyStatusDto>(status);
    //}

    //public async Task<UpdateFamilyStatusDto> CreateFamilyStatusForUserProfileAsync(CreateFamilyStatusDto familyStatusDto, int userProfileId)
    //{
    //    var familyStatus = _mapper.Map<FamilyStatus>(familyStatusDto);
    //    familyStatus.UserProfileId = userProfileId;

    //    _context.FamilyStatuses.Add(familyStatus);
    //    await _context.SaveChangesAsync();

    //    return _mapper.Map<UpdateFamilyStatusDto>(familyStatus);
    //}

    //public async Task<UpdateFamilyStatusDto> UpdateFamilyStatusForUserProfileAsync(UpdateFamilyStatusDto familyStatusDto, int userProfileId)
    //{
    //    var familyStatus = await _context.FamilyStatuses
    //        .FirstOrDefaultAsync(fs => fs.Id == familyStatusDto.Id && fs.UserProfileId == userProfileId);

    //    if (familyStatus == null)
    //    {
    //        return null;
    //    }

    //    _mapper.Map(familyStatusDto, familyStatus);
    //    await _context.SaveChangesAsync();

    //    return _mapper.Map<UpdateFamilyStatusDto>(familyStatus);
    //}

    //public async Task<bool> DeleteFamilyStatusForUserProfileAsync(int id, int userProfileId)
    //{
    //    var familyStatus = await _context.FamilyStatuses
    //        .FirstOrDefaultAsync(fs => fs.Id == id && fs.UserProfileId == userProfileId);

    //    if (familyStatus == null)
    //    {
    //        return false;
    //    }

    //    _context.FamilyStatuses.Remove(familyStatus);
    //    await _context.SaveChangesAsync();
    //    return true;
    //}
}