using AutoMapper;
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
    private readonly IMapper _mapper;

    public UserProfileEducationService(HRMatrixDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
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
                Translations = _mapper.Map<List<EducationLevelTranslationDto>>(education.EducationLevel.Translations)
            }).ToList()
        };

        return userProfileEducationListDto;
    }
    
    public async Task<UserProfileEducationResponse> CreateUserProfileEducationAsync(CreateUserProfileEducationRequest educationRequest)
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
        await _context.SaveChangesAsync();
        
        var educationLevel = await _context.EducationLevels
            .Include(el => el.Translations)
            .FirstOrDefaultAsync(el => el.Id == educationRequest.EducationLevelId);
        
        return new UserProfileEducationResponse
        {
            EducationLevelId = educationLevel.Id,
            EducationLevelName = educationLevel.Name,
            Quantity = newEducation.Quantity,
            Translations = _mapper.Map<List<EducationLevelTranslationDto>>(educationLevel.Translations)
        };
    }
    
    public async Task<UserProfileEducationListResponse> CreateUserProfileEducationsAsync(int userProfileId, List<UserEducationEntryRequest> educationRequests)
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

        await _context.SaveChangesAsync();

        return await GetUserProfileEducationsAsync(userProfileId);
    }

    public async Task<UserProfileEducationListResponse> UpdateUserProfileEducationsAsync(UpdateUserProfileEducationRequest updateRequest)
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

        await _context.SaveChangesAsync();
        
        return await GetUserProfileEducationsAsync(updateRequest.UserProfileId);
    }
}