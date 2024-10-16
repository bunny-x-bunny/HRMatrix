using AutoMapper;
using HRMatrix.Application.DTOs.EducationLevel;
using HRMatrix.Application.DTOs.UserProfile;
using HRMatrix.Application.DTOs.UserProfileEducation;
using HRMatrix.Application.Services.Interfaces;
using HRMatrix.Domain.Entities;
using HRMatrix.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace HRMatrix.Application.Services;

public class UserProfileService : IUserProfileService
{
    private readonly HRMatrixDbContext _context;
    private readonly IMapper _mapper;

    public UserProfileService(HRMatrixDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<UserProfileDto>> GetAllUserProfilesAsync()
    {
        var profiles = await _context.UserProfiles
            .Include(up => up.FamilyStatus)
            .ThenInclude(fs => fs.MaritalStatus)
            .ThenInclude(ms => ms.Translations)
            .Include(up => up.UserEducations)
            .ThenInclude(ue => ue.EducationLevel)
            .ThenInclude(el => el.Translations)
            .ToListAsync();
        
        var userProfilesDto = _mapper.Map<List<UserProfileDto>>(profiles);
        
        foreach (var userProfile in userProfilesDto)
        {
            userProfile.UserEducations = profiles
                .First(p => p.Id == userProfile.Id)
                .UserEducations.Select(ue => new UserProfileEducationResponse
                {
                    EducationLevelId = ue.EducationLevelId,
                    EducationLevelName = ue.EducationLevel.Name,
                    Quantity = ue.Quantity,
                    Translations = _mapper.Map<List<EducationLevelTranslationDto>>(ue.EducationLevel.Translations)
                }).ToList();
        }

        return userProfilesDto;
    }

    public async Task<UserProfileDto> GetUserProfileByIdAsync(int id)
    {
        var profile = await _context.UserProfiles
            .Include(up => up.FamilyStatus)
            .ThenInclude(fs => fs.MaritalStatus)
            .ThenInclude(ms => ms.Translations)
            .Include(up => up.UserEducations)
            .ThenInclude(ue => ue.EducationLevel)
            .ThenInclude(el => el.Translations)
            .FirstOrDefaultAsync(up => up.Id == id);

        if (profile == null) return null;
        
        var userProfileDto = _mapper.Map<UserProfileDto>(profile);

        userProfileDto.UserEducations = profile.UserEducations.Select(ue => new UserProfileEducationResponse
        {
            EducationLevelId = ue.EducationLevelId,
            EducationLevelName = ue.EducationLevel.Name,
            Quantity = ue.Quantity,
            Translations = _mapper.Map<List<EducationLevelTranslationDto>>(ue.EducationLevel.Translations)
        }).ToList();

        return userProfileDto;
    }

    public async Task<UserProfileDto> CreateUserProfileAsync(CreateUserProfileDto userProfileDto)
    {
        var userProfile = _mapper.Map<UserProfile>(userProfileDto);
        
        if (userProfile.FamilyStatus != null)
        {
            _context.FamilyStatuses.Add(userProfile.FamilyStatus);
        }
        
        if (userProfileDto.UserEducations != null)
        {
            foreach (var education in userProfileDto.UserEducations)
            {
                var userEducation = new UserProfileEducation
                {
                    UserProfile = userProfile,
                    EducationLevelId = education.EducationLevelId,
                    Quantity = education.Quantity
                };
                _context.UserProfileEducations.Add(userEducation);
            }
        }

        _context.UserProfiles.Add(userProfile);
        await _context.SaveChangesAsync();
        var updateUserProfileDto = await GetUserProfileByIdAsync(userProfile.Id);
        return updateUserProfileDto;
    }

    public async Task<UserProfileDto> UpdateUserProfileAsync(UpdateUserProfileDto userProfileDto)
    {
        var userProfile = await _context.UserProfiles
        .Include(up => up.FamilyStatus)
            .ThenInclude(fs => fs.MaritalStatus)
        .Include(up => up.UserEducations)
            .ThenInclude(ue => ue.EducationLevel)
        .FirstOrDefaultAsync(up => up.Id == userProfileDto.Id);

        if (userProfile == null)
            return null;
        
        _mapper.Map(userProfileDto, userProfile);

        var oldEducations = await _context.UserProfileEducations
            .Where(ue => ue.UserProfileId == userProfile.Id)
            .ToListAsync();
        
        if (oldEducations.Any())
        {
            _context.UserProfileEducations.RemoveRange(oldEducations);
            await _context.SaveChangesAsync();
        }

        foreach (var education in userProfileDto.UserEducations)
        {
            var userEducation = new UserProfileEducation
            {
                UserProfileId = userProfile.Id,
                EducationLevelId = education.EducationLevelId,
                Quantity = education.Quantity
            };
            _context.UserProfileEducations.Add(userEducation);
        }

        await _context.SaveChangesAsync();

        var createdProfile = await GetUserProfileByIdAsync(userProfile.Id);
        return createdProfile;
    }

    public async Task<bool> DeleteUserProfileAsync(int id)
    {
        var userProfile = await _context.UserProfiles.FindAsync(id);
        if (userProfile == null)
        {
            return false;
        }

        _context.UserProfiles.Remove(userProfile);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task UpdateProfileDocuments(int profileId, string photoFileName, string videoFileName)
    {
        var profile = await _context.UserProfiles.FirstOrDefaultAsync(x=>x.Id == profileId);  
        if (profile == null)
            return;
        profile.ProfilePhotoPath = photoFileName;
        profile.VideoPath = videoFileName;
        await _context.SaveChangesAsync();
    }
}
