using AutoMapper;
using HRMatrix.Application.DTOs.Languages;
using HRMatrix.Application.DTOs.UserProfilesLanguages;
using HRMatrix.Application.Services.Interfaces;
using HRMatrix.Domain.Entities;
using HRMatrix.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace HRMatrix.Application.Services;

public class UserProfileLanguageService : IUserProfileLanguageService
{
    private readonly HRMatrixDbContext _context;
    private readonly IMapper _mapper;

    public UserProfileLanguageService(HRMatrixDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<UserProfileLanguageListResponse> GetUserProfileLanguagesAsync(int userProfileId)
    {
        var userProfileLanguages = await _context.UserProfileLanguages
            .Include(up => up.Language)
            .Include(up => up.Language.Translations)
            .Where(up => up.UserProfileId == userProfileId)
            .ToListAsync();

        var languageResponses = userProfileLanguages.Select(upLanguage => new UserProfileLanguageResponse
        {
            LanguageId = upLanguage.LanguageId,
            LanguageName = upLanguage.Language.Name,
            ProficiencyLevel = upLanguage.ProficiencyLevel,
            Translations = _mapper.Map<List<LanguageTranslationDto>>(upLanguage.Language.Translations)
        }).ToList();

        return new UserProfileLanguageListResponse
        {
            UserProfileId = userProfileId,
            Languages = languageResponses
        };
    }

    public async Task<int> CreateUserProfileLanguagesAsync(List<CreateUserProfileLanguageRequest> languagesRequest, UserProfile user, bool withSave = false) {
        user.UserProfileLanguages = languagesRequest.Select(language => new UserProfileLanguage {
            LanguageId = language.LanguageId,
            ProficiencyLevel = language.ProficiencyLevel
        }).ToList();

        if (withSave)
            await _context.SaveChangesAsync();

        return user.Id;
    }

    public async Task<int> UpdateUserProfileLanguagesAsync(List<CreateUserProfileLanguageRequest> languagesRequest, UserProfile user, bool withSave = false)
    {
        var existingLanguages = await _context.UserProfileLanguages
            .Where(up => up.UserProfileId == user.Id)
            .ToListAsync();
        _context.UserProfileLanguages.RemoveRange(existingLanguages);

        user.UserProfileLanguages = languagesRequest.Select(language => new UserProfileLanguage {
            LanguageId = language.LanguageId,
            ProficiencyLevel = language.ProficiencyLevel
        }).ToList();

        if (withSave)
            await _context.SaveChangesAsync();

        return user.Id;
    }

    public async Task<bool> DeleteUserProfileLanguageAsync(int id)
    {
        var language = await _context.UserProfileLanguages.FindAsync(id);
        if (language == null) return false;

        _context.UserProfileLanguages.Remove(language);
        await _context.SaveChangesAsync();
        return true;
    }
}