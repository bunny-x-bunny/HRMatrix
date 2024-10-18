using AutoMapper;
using HRMatrix.Application.DTOs.EducationLevel;
using HRMatrix.Application.DTOs.Skill;
using HRMatrix.Application.DTOs.UserProfile;
using HRMatrix.Application.DTOs.UserProfileEducation;
using HRMatrix.Application.DTOs.UserProfileSkills;
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
            .Include(x => x.UserProfileSkills)
            .ThenInclude(x => x.Skill)
            .ThenInclude(x => x.Translations)
            .Include(x=>x.WorkExperiences)
            .Include(x=>x.UserProfileLanguages)
            .ThenInclude(x=>x.Language)
            .ThenInclude(x=>x.Translations)
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
        
        userProfileDto.UserProfileSkills = profile.UserProfileSkills.Select(s => new UserProfileSkillResponse
        {
            SkillId = s.SkillId,
            SkillName = s.Skill.Name,
            ProficiencyLevel = s.ProficiencyLevel,
            Translations = _mapper.Map<List<SkillTranslationDto>>(s.Skill.Translations)
        }).ToList();

        return userProfileDto;
    }

    public async Task<int> CreateUserProfileAsync(CreateUserProfileDto userProfileDto)
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

        if(userProfileDto.UserProfileSkills != null)
        {
            foreach(var skill in userProfileDto.UserProfileSkills)
            {
                var userProfileSkill = new UserProfileSkill
                {
                    UserProfile = userProfile,
                    SkillId = skill.SkillId,
                    ProficiencyLevel = skill.ProficiencyLevel
                };
                _context.UserProfileSkills.Add(userProfileSkill);
            }
        }

        if (userProfileDto.WorkExperiences != null)
        {
            foreach (var workExperience in userProfileDto.WorkExperiences)
            {
                var userWorkExperience = new WorkExperience
                {
                    UserProfile = userProfile,
                    CompanyName = workExperience.CompanyName,
                    Position = workExperience.Position,
                    StartDate = workExperience.StartDate,
                    EndDate = workExperience.EndDate,
                    Achievements = workExperience.Achievements
                };
                _context.WorkExperiences.Add(userWorkExperience);
            }
        }

        _context.UserProfiles.Add(userProfile);
        await _context.SaveChangesAsync();
        return userProfile.Id;
    }

    public async Task<UserProfileDto> UpdateUserProfileAsync(UpdateUserProfileDto userProfileDto)
    {
        var userProfile = await _context.UserProfiles
        .Include(up => up.FamilyStatus)
            .ThenInclude(fs => fs.MaritalStatus)
        .Include(up => up.UserEducations)
            .ThenInclude(ue => ue.EducationLevel)
        .Include(x => x.UserProfileSkills)
            .ThenInclude(x => x.Skill)
        .Include(x => x.WorkExperiences)
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

        var oldSkills = await _context.UserProfileSkills
            .Where(ue => ue.UserProfileId == userProfile.Id)
            .ToListAsync();

        if (oldSkills.Any())
        {
            _context.UserProfileSkills.RemoveRange(oldSkills);  
            await _context.SaveChangesAsync();
        }

        foreach(var skills in userProfileDto.UserProfileSkills)
        {
            var userProfileSkill = new UserProfileSkill
            {
                UserProfileId = userProfile.Id,
                SkillId = skills.SkillId,
                ProficiencyLevel = skills.ProficiencyLevel
            };
            _context.UserProfileSkills.Add(userProfileSkill);
        }   

        var oldWorkExpiriences = _context.WorkExperiences
            .Where(we => we.UserProfileId == userProfile.Id)
            .ToList();

        if (oldWorkExpiriences.Any())
        {
            _context.WorkExperiences.RemoveRange(oldWorkExpiriences);   
            await _context.SaveChangesAsync();
        }

        foreach (var workExperience in userProfileDto.WorkExperiences)
        {
            var userWorkExperience = new WorkExperience
            {
                UserProfile = userProfile,
                CompanyName = workExperience.CompanyName,
                Position = workExperience.Position,
                StartDate = workExperience.StartDate,
                EndDate = workExperience.EndDate,
                Achievements = workExperience.Achievements
            };
            _context.WorkExperiences.Add(userWorkExperience);
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
