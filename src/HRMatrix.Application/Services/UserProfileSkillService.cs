using HRMatrix.Application.DTOs.Skill;
using HRMatrix.Application.DTOs.UserProfileSkills;
using HRMatrix.Domain.Entities;
using HRMatrix.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace HRMatrix.Application.Services;

public class UserProfileSkillService : IUserProfileSkillService
{
    private readonly HRMatrixDbContext _context;

    public UserProfileSkillService(HRMatrixDbContext context)
    {
        _context = context;
    }

    public async Task<UserProfileSkillListResponse> GetUserProfileSkillsAsync(int userProfileId)
    {
        var userProfileSkills = await _context.UserProfileSkills
            .Include(up => up.Skill)
            .Include(up => up.Skill.Translations)
            .Where(up => up.UserProfileId == userProfileId)
            .ToListAsync();

        var skillResponses = userProfileSkills.Select(upSkill => new UserProfileSkillResponse
        {
            SkillId = upSkill.SkillId,
            SkillName = upSkill.Skill.Name,
            ProficiencyLevel = upSkill.ProficiencyLevel,
            Translations = upSkill.Skill.Translations.Select(t => new SkillTranslationDto {
                Id = t.Id,
                LanguageCode = t.LanguageCode,
                Name = t.Name
            }).ToList()
        }).ToList();

        return new UserProfileSkillListResponse
        {
            UserProfileId = userProfileId,
            Skills = skillResponses
        };
    }

    public async Task<int> UpsertUserProfileSkillsAsync(CreateUserProfileSkillsRequest skillsRequest, bool withSave = false)
    {
        var userProfile = await _context.UserProfiles.FindAsync(skillsRequest.UserProfileId);

        if (userProfile == null)
        {
            throw new Exception($"User profile with ID {skillsRequest.UserProfileId} not found.");
        }
            
        var existingSkills = await _context.UserProfileSkills
            .Where(up => up.UserProfileId == skillsRequest.UserProfileId)
            .ToListAsync();
        _context.UserProfileSkills.RemoveRange(existingSkills);
            
        var newSkills = skillsRequest.Skills.Select(skill => new UserProfileSkill
        {
            UserProfileId = skillsRequest.UserProfileId,
            SkillId = skill.SkillId,
            ProficiencyLevel = skill.ProficiencyLevel
        }).ToList();

        _context.UserProfileSkills.AddRange(newSkills);
        if (withSave)
            await _context.SaveChangesAsync();

        return skillsRequest.UserProfileId;
    }

    public async Task<bool> DeleteUserProfileSkillAsync(int id, bool withSave = false)
    {
        var skill = await _context.UserProfileSkills.FindAsync(id);
        if (skill == null) return false;

        _context.UserProfileSkills.Remove(skill);
        if (withSave)
            await _context.SaveChangesAsync();
        return true;
    }
}