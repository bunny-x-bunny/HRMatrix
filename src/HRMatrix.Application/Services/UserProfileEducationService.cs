using HRMatrix.Application.DTOs.EducationLevel;
using HRMatrix.Application.DTOs.UserProfileEducation;
using HRMatrix.Application.Services.Interfaces;
using HRMatrix.Domain.Entities;
using HRMatrix.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;

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
        //    var userProfile = await _context.UserProfiles
        //        .Include(up => up.UserEducations)
        //        .ThenInclude(ue => ue.EducationLevel)
        //        .ThenInclude(el => el.Translations)
        //        .FirstOrDefaultAsync(up => up.Id == userProfileId);

        //    if (userProfile == null)
        //    {
        //        return null;
        //    }

        //    var userProfileEducationListDto = new UserProfileEducationListResponse
        //    {
        //        UserProfileId = userProfile.Id,
        //        Educations = userProfile.UserEducations.Select(education => new UserProfileEducationResponse
        //        {
        //            EducationLevelId = education.EducationLevelId,
        //            EducationLevelName = education.EducationLevel.Name,
        //            Quantity = education.Quantity,
        //            Translations = education.EducationLevel.Translations.Select(t => new EducationLevelTranslationDto {
        //                Id = t.Id,
        //                LanguageCode = t.LanguageCode,
        //                Name = t.Name
        //            }).ToList()
        //        }).ToList()
        //    };

        //    return userProfileEducationListDto;
        throw new NotImplementedException("Unimplemented: GetUserProfileEducationsAsync");
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
    
    public async Task<UserProfileEducationListResponse?> CreateUserProfileEducationsAsync(List<UserEducationEntryRequest> educationRequests, UserProfile user, bool withSave = false)
    {
        if (user.UserEducations == null)
            user.UserEducations = new List<UserProfileEducation>();
        foreach (var educationRequest in educationRequests)
        {
            var existingEducation = user.UserEducations
                .FirstOrDefault(ue => ue.EducationLevelId == educationRequest.EducationLevelId);

            if (existingEducation != null)
            {
                throw new Exception($"User already has education with level ID {educationRequest.EducationLevelId}");
            }

            var newEducation = new UserProfileEducation
            {
                EducationLevelId = educationRequest.EducationLevelId,
                Quantity = educationRequest.Quantity
            };

            user.UserEducations.Add(newEducation);
        }

        if (withSave) {
            await _context.SaveChangesAsync();
            return await GetUserProfileEducationsAsync(user.Id);
        } else {
            return null;
        }
    }

    public async Task<UserProfileEducationListResponse?> UpdateUserProfileEducationsAsync(List<UserEducationEntryRequest> educationRequests, UserProfile user, bool withSave = false)
    {
        var existingEducations = await _context.UserProfileEducations
            .Where(ue => ue.UserProfileId == user.Id)
            .ToListAsync();
        _context.UserProfileEducations.RemoveRange(existingEducations);

        user.UserEducations = educationRequests.Select(e => new UserProfileEducation {
            EducationLevelId = e.EducationLevelId,
            Quantity = e.Quantity
        }).ToList();

        if (withSave) {
            await _context.SaveChangesAsync();
            return await GetUserProfileEducationsAsync(user.Id);
        } else {
            return null;
        }
    }
}