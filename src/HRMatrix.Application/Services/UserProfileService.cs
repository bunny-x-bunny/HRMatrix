using AutoMapper;
using HRMatrix.Application.DTOs.City;
using HRMatrix.Application.DTOs.Common;
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
using HRMatrix.Application.DTOs.Specialization;
using HRMatrix.Application.DTOs.UserProfileWorkType;
using HRMatrix.Application.Settings;
using Microsoft.Extensions.Options;

namespace HRMatrix.Application.Services;

public class UserProfileService : IUserProfileService
{
    private readonly HRMatrixDbContext _context;
    private readonly IMapper _mapper;
    private readonly string _baseUrl;

    public UserProfileService(HRMatrixDbContext context, IMapper mapper, IOptions<AppSettings> appSettings)
    {
        _context = context;
        _mapper = mapper;
        _baseUrl = appSettings.Value.BaseUrl;
    }

    private int CalculateEducationScore(UserProfileDto userProfileDto)
    {
        if (userProfileDto.UserEducations.Any(ue => ue.EducationLevelId is 1 or 3 or 4))
            return 10;
        return userProfileDto.UserEducations.Any(ue => ue.EducationLevelId == 2) ? 5 : 1;
    }

    private int CalculateFamilyStatusScore(UserProfileDto userProfileDto)
    {
        var familyStatus = userProfileDto.FamilyStatus;

        if (familyStatus == null)
        {
            return 1; 
        }

        if (familyStatus.Id == 1)
        {
            return familyStatus.NumberOfChildren >= 2 ? 10 : 5;
        }
        else
        {
            return familyStatus.NumberOfChildren == 0 ? 1 : 5;
        }
    }

    private int CalculateAgeScore(UserProfileDto userProfileDto)
    {
        var currentDate = DateTime.Now;
        var age = currentDate.Year - userProfileDto.DateOfBirth.Year;
        
        if (userProfileDto.DateOfBirth.Date > currentDate.AddYears(-age)) age--;

        return age switch
        {
            >= 30 and <= 55 => 10,
            >= 27 and <= 57 => 5,
            _ => 1
        };
    }
    private int CalculateLanguageScore(UserProfileDto userProfileDto)
    {
        int languageCount = userProfileDto.Languages?.Count ?? 0;

        return languageCount switch
        {
            >= 3 => 10,
            2 => 6,
            1 => 3,
            _ => 0
        };
    }

    private int CalculateSkillScore(UserProfileDto userProfileDto)
    {
        if (userProfileDto.UserProfileSkills == null || userProfileDto.UserProfileSkills.Count == 0)
            return 0;
        
        var totalProficiency = userProfileDto.UserProfileSkills.Sum(skill => skill.ProficiencyLevel);
        var averageProficiency = totalProficiency / userProfileDto.UserProfileSkills.Count;

        return (int)Math.Round((decimal)averageProficiency);
    }

    public async Task<PaginatedResult<UserProfileSuggestionDto>> SearchUserProfilesAsync(
    string query = null,
    int limit = 10,
    List<int> categoryIds = null,
    List<int> specialtyIds = null,
    List<int> locationIds = null,
    List<int> workTypeIds = null,
    int page = 1,
    int pageSize = 10)
    {
        var tokens = string.IsNullOrWhiteSpace(query)
            ? new string[0]
            : query.ToLower().Split(" ", StringSplitOptions.RemoveEmptyEntries);

        var profilesQuery = _context.UserProfiles
            .Include(up => up.FamilyStatus)
                .ThenInclude(fs => fs.MaritalStatus)
                .ThenInclude(ms => ms.Translations)
            .Include(up => up.UserEducations)
                .ThenInclude(ue => ue.EducationLevel)
                .ThenInclude(el => el.Translations)
            .Include(x => x.UserProfileSkills)
                .ThenInclude(x => x.Skill)
                .ThenInclude(x => x.Translations)
            .Include(x => x.UserProfileSkills)
                .ThenInclude(x => x.Skill)
                .ThenInclude(x => x.Specialization)
                .ThenInclude(sp => sp.Translations)
            .Include(x => x.WorkExperiences)
            .Include(x => x.UserProfileLanguages)
                .ThenInclude(x => x.Language)
                .ThenInclude(x => x.Translations)
            .Include(x => x.UserProfileCompetencies)
                .ThenInclude(x => x.Competency)
                .ThenInclude(x => x.Translations)
            .Include(x => x.City)
                .ThenInclude(city => city.Country)
                .ThenInclude(country => country.Translations)
            .Include(x => x.City)
                .ThenInclude(city => city.Translations)
            .Include(x => x.UserProfileWorkTypes)
                .ThenInclude(wt => wt.WorkType)
            .AsNoTracking();

        // Filter by search tokens
        if (tokens.Length > 0)
        {
            foreach (var e in tokens)
            {
                profilesQuery = profilesQuery.Where(up =>
                    EF.Functions.Like(up.FirstName, $"%{e}%") ||
                    EF.Functions.Like(up.LastName, $"%{e}%"));
            }
        }

        // Apply additional filters
        if (categoryIds != null && categoryIds.Any())
        {
            profilesQuery = profilesQuery.Where(x => x.UserProfileSkills.Any(owt => categoryIds.Contains(owt.SkillId)));
        }

        if (specialtyIds != null && specialtyIds.Any())
        {
            profilesQuery = profilesQuery.Where(o => o.UserProfileSkills.Any(os => specialtyIds.Contains(os.Skill.SpecializationId.Value)));
        }

        if (locationIds != null && locationIds.Any())
        {
            profilesQuery = profilesQuery.Where(up => locationIds.Contains(up.CityId.Value));
        }

        if (workTypeIds != null && workTypeIds.Any())
        {
            profilesQuery = profilesQuery.Where(up =>
                up.UserProfileWorkTypes.Any(wt => workTypeIds.Contains(wt.WorkType.Id)));
        }

        // Get total count before applying pagination
        var totalItems = await profilesQuery.CountAsync();

        // Apply pagination
        var profiles = await profilesQuery
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .Select(up => new UserProfileSuggestionDto
            {
                Id = up.Id,
                FullName = $"{up.FirstName} {up.LastName}",
                UserProfileSkills = up.UserProfileSkills.Select(s => new UserProfileSkillResponse
                {
                    SkillId = s.SkillId,
                    SkillName = s.Skill.Name,
                    ProficiencyLevel = s.ProficiencyLevel,
                    Translations = _mapper.Map<List<SkillTranslationDto>>(s.Skill.Translations),
                    Specialization = new SpecializationDto
                    {
                        Id = s.Skill.Specialization.Id,
                        Name = s.Skill.Specialization.Name,
                        Translations = _mapper.Map<List<SpecializationTranslationDto>>(s.Skill.Specialization.Translations)
                    }
                }).ToList(),
                City = _mapper.Map<CityDto>(up.City),
            })
            .ToListAsync();

        return new PaginatedResult<UserProfileSuggestionDto>
        {
            Items = profiles,
            TotalItems = totalItems,
            Page = page,
            PageSize = pageSize,
            TotalPages = (int)Math.Ceiling(totalItems / (double)pageSize)
        };
    }

    public async Task<List<UserProfileDto>> GetAllUserProfilesAsync()
    {
        var profiles = _context.UserProfiles
            .Include(up => up.FamilyStatus)
            .ThenInclude(fs => fs.MaritalStatus)
            .ThenInclude(ms => ms.Translations.Where(t => t.LanguageCode == "ru-RU"))
            .Include(up => up.UserEducations)
            .ThenInclude(ue => ue.EducationLevel)
            .ThenInclude(el => el.Translations.Where(t => t.LanguageCode == "ru-RU"))
            .Include(x => x.UserProfileSkills)
            .ThenInclude(x => x.Skill)
            .ThenInclude(x => x.Translations.Where(t => t.LanguageCode == "ru-RU"))
            .Include(x => x.UserProfileSkills)
            .ThenInclude(x => x.Skill)
            .ThenInclude(x => x.Specialization)
            .ThenInclude(sp => sp.Translations.Where(t => t.LanguageCode == "ru-RU"))
            .Include(x => x.WorkExperiences)
            .Include(x => x.UserProfileLanguages)
            .ThenInclude(x => x.Language)
            .ThenInclude(x => x.Translations.Where(t => t.LanguageCode == "ru-RU"))
            .Include(x => x.UserProfileCompetencies)
            .ThenInclude(x => x.Competency)
            .ThenInclude(x => x.Translations.Where(t => t.LanguageCode == "ru-RU"))
            .Include(x => x.City)
            .ThenInclude(city => city.Country)
            .ThenInclude(country => country.Translations.Where(t => t.LanguageCode == "ru-RU"))
            .Include(x => x.City)
            .ThenInclude(city => city.Translations.Where(t => t.LanguageCode == "ru-RU"))
            .Include(x => x.UserProfileWorkTypes)
            .ThenInclude(wt => wt.WorkType)
            .AsNoTracking().ToList();

        var userProfilesDto = _mapper.Map<List<UserProfileDto>>(profiles);

        foreach (var userProfile in userProfilesDto)
        {
            // Формируем полный URL для фотографий и видео
            var profile = profiles.First(p => p.Id == userProfile.Id);
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
                    Translations = _mapper.Map<List<SkillTranslationDto>>(s.Skill.Translations),
                    Specialization = new SpecializationDto
                    {
                        Id = s.Skill.Specialization.Id,
                        Name = s.Skill.Specialization.Name,
                        Translations = _mapper.Map<List<SpecializationTranslationDto>>(s.Skill.Specialization.Translations)
                    }
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

            userProfile.WorkTypes = profiles
                .First(p => p.Id == userProfile.Id)
                .UserProfileWorkTypes.Select(wt => new UserProfileWorkTypeResponse
                {
                    WorkTypeId = wt.WorkTypeId,
                    WorkTypeName = wt.WorkType.Name
                }).ToList();
            userProfile.EducationScore = CalculateEducationScore(userProfile);
            userProfile.FamilyStatusScore = CalculateFamilyStatusScore(userProfile);
            userProfile.AgeScore = CalculateAgeScore(userProfile);
            userProfile.LanguageScore = CalculateLanguageScore(userProfile);
            userProfile.SkillScore = CalculateSkillScore(userProfile);
            userProfile.WorkScore = 3;
            userProfile.AllScore = (int)Math.Round((decimal)((userProfile.EducationScore +
                                                             userProfile.FamilyStatusScore + userProfile.AgeScore
                                                             + userProfile.LanguageScore + userProfile.SkillScore + userProfile.WorkScore) / 6));
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
            .Include(x => x.UserProfileSkills)
                .ThenInclude(x => x.Skill)
                    .ThenInclude(x => x.Specialization)
                        .ThenInclude(sp => sp.Translations)
            .Include(x => x.WorkExperiences)
            .Include(x => x.UserProfileLanguages)
                .ThenInclude(x => x.Language)
                .ThenInclude(x => x.Translations)
            .Include(x => x.UserProfileCompetencies)
                .ThenInclude(x => x.Competency)
                .ThenInclude(x => x.Translations)
            .Include(x => x.City)
                .ThenInclude(city => city.Country)
                .ThenInclude(country => country.Translations)
            .Include(x => x.City)
                .ThenInclude(city => city.Translations)
            .Include(x => x.UserProfileWorkTypes)
                .ThenInclude(wt => wt.WorkType)
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
            Translations = _mapper.Map<List<SkillTranslationDto>>(s.Skill.Translations),
            Specialization = new SpecializationDto
            {
                Id = s.Skill.Specialization.Id,
                Name = s.Skill.Specialization.Name,
                Translations = _mapper.Map<List<SpecializationTranslationDto>>(s.Skill.Specialization.Translations)
            }
        }).ToList();

        userProfileDto.Competencies = profile.UserProfileCompetencies.Select(c => new UserProfileCompetencyResponse
        {
            CompetencyId = c.CompetencyId,
            CompetencyName = c.Competency.Name,
            ProficiencyLevel = c.ProficiencyLevel,
            Translations = _mapper.Map<List<CompetencyTranslationDto>>(c.Competency.Translations)
        }).ToList();

        userProfileDto.WorkTypes = profile.UserProfileWorkTypes.Select(wt => new UserProfileWorkTypeResponse
        {
            WorkTypeId = wt.WorkTypeId,
            WorkTypeName = wt.WorkType.Name
        }).ToList();
        
        userProfileDto.EducationScore = CalculateEducationScore(userProfileDto);
        userProfileDto.FamilyStatusScore = CalculateFamilyStatusScore(userProfileDto);
        userProfileDto.AgeScore = CalculateAgeScore(userProfileDto);
        userProfileDto.LanguageScore = CalculateLanguageScore(userProfileDto);
        userProfileDto.SkillScore = CalculateSkillScore(userProfileDto);
        userProfileDto.WorkScore = 3;
        userProfileDto.AllScore = (int)Math.Round((decimal)((userProfileDto.EducationScore +
                                                             userProfileDto.FamilyStatusScore + userProfileDto.AgeScore
                                                             + userProfileDto.LanguageScore + userProfileDto.SkillScore + userProfileDto.WorkScore) / 6));
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
            .Include(x => x.City)
            .Include(x => x.UserProfileWorkTypes)
                .ThenInclude(x => x.WorkType)
            .FirstOrDefaultAsync(up => up.Id == userProfileDto.Id);

        if (userProfile == null)
            return null;

        _mapper.Map(userProfileDto, userProfile);

        userProfile.UserEducations.Clear();
        userProfile.UserProfileSkills.Clear();
        userProfile.WorkExperiences.Clear();
        userProfile.UserProfileLanguages.Clear();
        userProfile.UserProfileCompetencies.Clear();
        userProfile.UserProfileWorkTypes.Clear();

        _mapper.Map(userProfileDto.UserEducations, userProfile.UserEducations);
        _mapper.Map(userProfileDto.UserProfileSkills, userProfile.UserProfileSkills);
        _mapper.Map(userProfileDto.WorkExperiences, userProfile.WorkExperiences);
        _mapper.Map(userProfileDto.Languages, userProfile.UserProfileLanguages);
        _mapper.Map(userProfileDto.Competencies, userProfile.UserProfileCompetencies);
        _mapper.Map(userProfileDto.WorkTypes, userProfile.UserProfileWorkTypes);

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

            userProfile.EducationScore = CalculateEducationScore(userProfile);
            userProfile.FamilyStatusScore = CalculateFamilyStatusScore(userProfile);
            userProfile.AgeScore = CalculateAgeScore(userProfile);
            userProfile.LanguageScore = CalculateLanguageScore(userProfile);
            userProfile.SkillScore = CalculateSkillScore(userProfile);
            userProfile.WorkScore = 3;
            userProfile.AllScore = (int)Math.Round((decimal)((userProfile.EducationScore +
                                                              userProfile.FamilyStatusScore + userProfile.AgeScore
                                                              + userProfile.LanguageScore + userProfile.SkillScore + userProfile.WorkScore) / 6));
        }

        return userProfilesDto;
    }
}
