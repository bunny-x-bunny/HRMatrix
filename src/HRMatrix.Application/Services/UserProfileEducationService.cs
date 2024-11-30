using HRMatrix.Application.DTOs.EducationLevel;
using HRMatrix.Application.DTOs.UserProfileEducation;
using HRMatrix.Application.Services.Interfaces;
using HRMatrix.Domain.Entities;
using HRMatrix.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace HRMatrix.Application.Services;

public class UserProfileEducationService : IUserProfileEducationService
{
    private readonly HRMatrixDbContext _context;

    public UserProfileEducationService(HRMatrixDbContext context)
    {
        _context = context;
    }

    public async Task<UserProfileEducationListResponse> GetUserProfileEducationsAsync(int userProfileId)
    {
        var userProfile = await _context.UserProfiles
            .Include(up => up.UserEducations)
            .ThenInclude(ue => ue.EducationLevel)
            .ThenInclude(el => el.Translations)
            .FirstOrDefaultAsync(up => up.Id == userProfileId);

        if (userProfile == null)
        {
            return null;
        }
        
        var userProfileEducationListDto = new UserProfileEducationListResponse
        {
            UserProfileId = userProfile.Id,
            Educations = userProfile.UserEducations.Select(education => new UserProfileEducationResponse
            {
                EducationLevelId = education.EducationLevelId,
                EducationLevelName = education.EducationLevel.Name,
                Quantity = education.Quantity,
                Translations = education.EducationLevel.Translations.Select(t => new EducationLevelTranslationDto {
                    Id = t.Id,
                    LanguageCode = t.LanguageCode,
                    Name = t.Name
                }).ToList()
            }).ToList()
        };

        return userProfileEducationListDto;
    }
    
    public async Task<UserProfileEducationResponse> CreateUserProfileEducationAsync(CreateUserProfileEducationRequest educationRequest, bool withSave = false)
    {
        var userProfile = await _context.UserProfiles
            .Include(up => up.UserEducations)
            .FirstOrDefaultAsync(up => up.Id == educationRequest.UserProfileId);

        if (userProfile == null)
        {
            throw new Exception($"User profile with ID {educationRequest.UserProfileId} not found.");
        }

        var existingEducation = userProfile.UserEducations
            .FirstOrDefault(ue => ue.EducationLevelId == educationRequest.EducationLevelId);

        if (existingEducation != null)
        {
            throw new Exception($"User already has education with level ID {educationRequest.EducationLevelId}");
        }
        
        var newEducation = new UserProfileEducation
        {
            UserProfileId = educationRequest.UserProfileId,
            EducationLevelId = educationRequest.EducationLevelId,
            Quantity = educationRequest.Quantity
        };

        userProfile.UserEducations.Add(newEducation);
        if (withSave)
            await _context.SaveChangesAsync();
        
        var educationLevel = await _context.EducationLevels
            .Include(el => el.Translations)
            .FirstOrDefaultAsync(el => el.Id == educationRequest.EducationLevelId);
        
        return new UserProfileEducationResponse
        {
            EducationLevelId = educationLevel.Id,
            EducationLevelName = educationLevel.Name,
            Quantity = newEducation.Quantity,
            Translations = educationLevel.Translations.Select(t => new EducationLevelTranslationDto {
                Id = t.Id,
                LanguageCode = t.LanguageCode,
                Name = t.Name
            }).ToList()
        };
    }
    
    public async Task<UserProfileEducationListResponse?> CreateUserProfileEducationsAsync(int userProfileId, List<UserEducationEntryRequest> educationRequests, bool withSave = false)
    {
        var userProfile = await _context.UserProfiles
            .Include(up => up.UserEducations)
            .FirstOrDefaultAsync(up => up.Id == userProfileId);

        if (userProfile == null)
        {
            throw new Exception($"User profile with ID {userProfileId} not found.");
        }

        foreach (var educationRequest in educationRequests)
        {
            var existingEducation = userProfile.UserEducations
                .FirstOrDefault(ue => ue.EducationLevelId == educationRequest.EducationLevelId);

            if (existingEducation != null)
            {
                throw new Exception($"User already has education with level ID {educationRequest.EducationLevelId}");
            }

            var newEducation = new UserProfileEducation
            {
                UserProfileId = userProfileId,
                EducationLevelId = educationRequest.EducationLevelId,
                Quantity = educationRequest.Quantity
            };

            userProfile.UserEducations.Add(newEducation);
        }

        if (withSave) {
            await _context.SaveChangesAsync();
            return await GetUserProfileEducationsAsync(userProfileId);
        } else {
            return null;
        }
    }

    public async Task<UserProfileEducationListResponse?> UpdateUserProfileEducationsAsync(UpdateUserProfileEducationRequest updateRequest, bool withSave = false)
    {
        var userProfile = await _context.UserProfiles
            .Include(up => up.UserEducations)
            .FirstOrDefaultAsync(up => up.Id == updateRequest.UserProfileId);

        if (userProfile == null)
        {
            throw new Exception($"User profile with ID {updateRequest.UserProfileId} not found.");
        }
        
        _context.UserProfileEducations.RemoveRange(userProfile.UserEducations);
        
        foreach (var educationRequest in updateRequest.Educations)
        {
            var newEducation = new UserProfileEducation
            {
                UserProfileId = updateRequest.UserProfileId,
                EducationLevelId = educationRequest.EducationLevelId,
                Quantity = educationRequest.Quantity
            };

            userProfile.UserEducations.Add(newEducation);
        }

        if (withSave) {
            await _context.SaveChangesAsync();
            return await GetUserProfileEducationsAsync(updateRequest.UserProfileId);
        } else {
            return null;
        }
    }
}