using AutoMapper;
using HRMatrix.Application.DTOs.FamilyStatus;
using HRMatrix.Application.Services.Interfaces;
using HRMatrix.Domain.Entities;
using HRMatrix.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace HRMatrix.Application.Services;

public class UserProfileFamilyStatusService : IUserProfileFamilyStatusService
{
    private readonly HRMatrixDbContext _context;
    private readonly IMapper _mapper;

    public UserProfileFamilyStatusService(HRMatrixDbContext context, IMapper mapper) {
        _context = context;
        _mapper = mapper;
    }

    //public async Task<List<UpdateFamilyStatusDto>> GetAllFamilyStatusesForUserProfileAsync(int userProfileId)
    //{
    //    var statuses = await _context.FamilyStatuses
    //        .Include(fs => fs.MaritalStatus)
    //        .Where(fs => fs.UserProfileId == userProfileId)
    //        .ToListAsync();

    //    return _mapper.Map<List<UpdateFamilyStatusDto>>(statuses);
    //}

    public async Task<int> CreateFamilyStatusForUserProfileAsync(CreateFamilyStatusDto familyStatusDto, UserProfile user, bool withSave = false) {
        var familyStatus = new FamilyStatus {
            UserProfile = user,
            MaritalStatusId = familyStatusDto.MaritalStatusId,
            TimesMarried = familyStatusDto.TimesMarried,
            MarriagePeriods = familyStatusDto.MarriagePeriods,
            NumberOfChildren = familyStatusDto.NumberOfChildren
        };

        _context.FamilyStatuses.Add(familyStatus);
        if(withSave)
            await _context.SaveChangesAsync();
        return familyStatus.Id;
    }

    public async Task<bool> UpdateFamilyStatusForUserProfileAsync(UpdateFamilyStatusDto familyStatusDto, UserProfile user) {
        var familyStatus = await _context.FamilyStatuses
            .FirstOrDefaultAsync(fs => fs.UserProfileId == user.Id);

        if (familyStatus == null) {
            return false;
        }

        familyStatus.MaritalStatusId = familyStatusDto.MaritalStatusId;
        familyStatus.TimesMarried = familyStatusDto.TimesMarried;
        familyStatus.MarriagePeriods = familyStatusDto.MarriagePeriods;
        familyStatus.NumberOfChildren = familyStatusDto.NumberOfChildren;

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteFamilyStatusForUserProfileAsync(UserProfile user) {
        var familyStatus = await _context.FamilyStatuses
            .FirstOrDefaultAsync(fs => fs.UserProfileId == user.Id);

        if (familyStatus == null) {
            return false;
        }

        _context.FamilyStatuses.Remove(familyStatus);
        await _context.SaveChangesAsync();
        return true;
    }
}