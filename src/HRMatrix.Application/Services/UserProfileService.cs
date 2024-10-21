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
using HRMatrix.Application.DTOs.Competency;
using HRMatrix.Application.DTOs.UserProfileCompetency;

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
            .Include(x => x.UserProfileSkills)
                .ThenInclude(x => x.Skill)
                .ThenInclude(x => x.Translations)
            .Include(x => x.WorkExperiences)
            .Include(x => x.UserProfileLanguages)
                .ThenInclude(x => x.Language)
                .ThenInclude(x => x.Translations)
            .Include(x => x.UserProfileCompetencies)
                .ThenInclude(x => x.Competency)
                .ThenInclude(x => x.Translations)
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

            userProfile.UserProfileSkills = profiles
                .First(p => p.Id == userProfile.Id)
                .UserProfileSkills.Select(s => new UserProfileSkillResponse
                {
                    SkillId = s.SkillId,
                    SkillName = s.Skill.Name,
                    ProficiencyLevel = s.ProficiencyLevel,
                    Translations = _mapper.Map<List<SkillTranslationDto>>(s.Skill.Translations)
                }).ToList();

            userProfile.Competencies = profiles
                .First(p => p.Id == userProfile.Id)
                .UserProfileCompetencies.Select(c => new UserProfileCompetencyResponse
                {
                    CompetencyId = c.CompetencyId,
                    CompetencyName = c.Competency.Name,
                    ProficiencyLevel = c.ProficiencyLevel,
                    Translations = _mapper.Map<List<CompetencyTranslationDto>>(c.Competency.Translations)
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
            .Include(x => x.WorkExperiences)
            .Include(x => x.UserProfileLanguages)
                .ThenInclude(x => x.Language)
                .ThenInclude(x => x.Translations)
            .Include(x => x.UserProfileCompetencies)
                .ThenInclude(x => x.Competency)
                .ThenInclude(x => x.Translations)
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

        userProfileDto.Competencies = profile.UserProfileCompetencies.Select(c => new UserProfileCompetencyResponse
        {
            CompetencyId = c.CompetencyId,
            CompetencyName = c.Competency.Name,
            ProficiencyLevel = c.ProficiencyLevel,
            Translations = _mapper.Map<List<CompetencyTranslationDto>>(c.Competency.Translations)
        }).ToList();

        return userProfileDto;
    }

    public async Task<int> CreateUserProfileAsync(CreateUserProfileDto userProfileDto, int userId)
    {
        var userProfile = _mapper.Map<UserProfile>(userProfileDto);
        userProfile.AspNetUserId = userId;
        _context.UserProfiles.Add(userProfile);
        await _context.SaveChangesAsync();
        return userProfile.Id;
    }

    public async Task<UserProfileDto> UpdateUserProfileAsync(UpdateUserProfileDto userProfileDto, int userId)
    {
        var userProfile = await _context.UserProfiles
            .Include(up => up.FamilyStatus)
                .ThenInclude(fs => fs.MaritalStatus)
            .Include(up => up.UserEducations)
                .ThenInclude(ue => ue.EducationLevel)
            .Include(x => x.UserProfileSkills)
                .ThenInclude(x => x.Skill)
            .Include(x => x.WorkExperiences)
            .Include(x => x.UserProfileLanguages)
                .ThenInclude(x => x.Language)
            .Include(x => x.UserProfileCompetencies)
                .ThenInclude(x => x.Competency)
            .FirstOrDefaultAsync(up => up.Id == userProfileDto.Id);

        if (userProfile == null)
            return null;

        _mapper.Map(userProfileDto, userProfile);

        userProfile.UserEducations.Clear();
        userProfile.UserProfileSkills.Clear();
        userProfile.WorkExperiences.Clear();
        userProfile.UserProfileLanguages.Clear();
        userProfile.UserProfileCompetencies.Clear();

        _mapper.Map(userProfileDto.UserEducations, userProfile.UserEducations);
        _mapper.Map(userProfileDto.UserProfileSkills, userProfile.UserProfileSkills);
        _mapper.Map(userProfileDto.WorkExperiences, userProfile.WorkExperiences);
        _mapper.Map(userProfileDto.Languages, userProfile.UserProfileLanguages);
        _mapper.Map(userProfileDto.Competencies, userProfile.UserProfileCompetencies);
        
        await _context.SaveChangesAsync();

        var updatedProfile = await GetUserProfileByIdAsync(userProfile.Id);
        return updatedProfile;
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
        var profile = await _context.UserProfiles.FirstOrDefaultAsync(x => x.Id == profileId);
        if (profile == null)
            return;
        profile.ProfilePhotoPath = photoFileName;
        profile.VideoPath = videoFileName;
        await _context.SaveChangesAsync();
    }

    public async Task<List<UserProfileSuggestionDto>> SearchUserProfilesAsync(string query, int limit)
    {
        query = query.ToLower();

        var profiles = await _context.UserProfiles.AsNoTracking()
            .Where(up => up.FirstName.ToLower().Contains(query) || up.LastName.ToLower().Contains(query))
            .Select(up => new UserProfileSuggestionDto
            {
                Id = up.Id,
                FullName = $"{up.FirstName} {up.LastName}"
            })
            .Take(limit)
            .ToListAsync();

        return profiles;
    }

    public async Task<List<UserProfileDto>> GetUserProfileByAspNetUserId(int id)
    {
        var profiles = await _context.UserProfiles
            .Include(up => up.FamilyStatus)
                .ThenInclude(fs => fs.MaritalStatus)
                .ThenInclude(ms => ms.Translations)
            .Include(up => up.UserEducations)
                .ThenInclude(ue => ue.EducationLevel)
                .ThenInclude(el => el.Translations)
            .Include(x => x.UserProfileSkills)
                .ThenInclude(x => x.Skill)
                .ThenInclude(x => x.Translations)
            .Include(x => x.WorkExperiences)
            .Include(x => x.UserProfileLanguages)
                .ThenInclude(x => x.Language)
                .ThenInclude(x => x.Translations)
            .Include(x => x.UserProfileCompetencies)
                .ThenInclude(x => x.Competency)
                .ThenInclude(x => x.Translations)
            .Where(x=>x.AspNetUserId == id)
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

            userProfile.UserProfileSkills = profiles
                .First(p => p.Id == userProfile.Id)
                .UserProfileSkills.Select(s => new UserProfileSkillResponse
                {
                    SkillId = s.SkillId,
                    SkillName = s.Skill.Name,
                    ProficiencyLevel = s.ProficiencyLevel,
                    Translations = _mapper.Map<List<SkillTranslationDto>>(s.Skill.Translations)
                }).ToList();

            userProfile.Competencies = profiles
                .First(p => p.Id == userProfile.Id)
                .UserProfileCompetencies.Select(c => new UserProfileCompetencyResponse
                {
                    CompetencyId = c.CompetencyId,
                    CompetencyName = c.Competency.Name,
                    ProficiencyLevel = c.ProficiencyLevel,
                    Translations = _mapper.Map<List<CompetencyTranslationDto>>(c.Competency.Translations)
                }).ToList();
        }

        return userProfilesDto;
    }
}
