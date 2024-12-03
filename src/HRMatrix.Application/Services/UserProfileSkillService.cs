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

    //public async Task<UserProfileSkillListResponse> GetUserProfileSkillsAsync(int userProfileId)
    //{
    //    var userProfileSkills = await _context.UserProfileSkills
    //        .Include(up => up.Skill)
    //        .Include(up => up.Skill.Translations)
    //        .Where(up => up.UserProfileId == userProfileId)
    //        .ToListAsync();

    //    var skillResponses = userProfileSkills.Select(upSkill => new UserProfileSkillResponse
    //    {
    //        SkillId = upSkill.SkillId,
    //        SkillName = upSkill.Skill.Name,
    //        ProficiencyLevel = upSkill.ProficiencyLevel,
    //        Translations = upSkill.Skill.Translations.Select(t => new SkillTranslationDto {
    //            Id = t.Id,
    //            LanguageCode = t.LanguageCode,
    //            Name = t.Name
    //        }).ToList()
    //    }).ToList();

    //    return new UserProfileSkillListResponse
    //    {
    //        UserProfileId = userProfileId,
    //        Skills = skillResponses
    //    };
    //}

    public async Task<int> CreateUserProfileSkillsAsync(List<CreateUserProfileSkillRequest> skillsRequest, UserProfile user, bool withSave = false) {
        user.UserProfileSkills = skillsRequest.Select(skill => new UserProfileSkill {
            SkillId = skill.SkillId,
            ProficiencyLevel = skill.ProficiencyLevel
        }).ToList();

        if (withSave)
            await _context.SaveChangesAsync();

        return user.Id;
    }

    public async Task<int> UpdateUserProfileSkillsAsync(List<CreateUserProfileSkillRequest> skillsRequest, UserProfile user, bool withSave = false)
    {
        var existingSkills = await _context.UserProfileSkills
            .Where(up => up.UserProfileId == user.Id)
            .ToListAsync();
        _context.UserProfileSkills.RemoveRange(existingSkills);
            
        user.UserProfileSkills = skillsRequest.Select(skill => new UserProfileSkill {
            SkillId = skill.SkillId,
            ProficiencyLevel = skill.ProficiencyLevel
        }).ToList();

        if (withSave)
            await _context.SaveChangesAsync();

        return user.Id;
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