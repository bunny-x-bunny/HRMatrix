using AutoMapper;
using HRMatrix.Application.DTOs.Skill;
using HRMatrix.Application.DTOs.UserProfileSkills;
using HRMatrix.Domain.Entities;
using HRMatrix.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace HRMatrix.Application.Services;

public class UserProfileSkillService : IUserProfileSkillService
{
    private readonly HRMatrixDbContext _context;
    private readonly IMapper _mapper;

    public UserProfileSkillService(HRMatrixDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
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
            Translations = _mapper.Map<List<SkillTranslationDto>>(upSkill.Skill.Translations)
        }).ToList();

        return new UserProfileSkillListResponse
        {
            UserProfileId = userProfileId,
            Skills = skillResponses
        };
    }

    public async Task<int> UpsertUserProfileSkillsAsync(CreateUserProfileSkillsRequest skillsRequest)
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

        await _context.UserProfileSkills.AddRangeAsync(newSkills);
        await _context.SaveChangesAsync();

        return skillsRequest.UserProfileId;
    }

    public async Task<bool> DeleteUserProfileSkillAsync(int id)
    {
        var skill = await _context.UserProfileSkills.FindAsync(id);
        if (skill == null) return false;

        _context.UserProfileSkills.Remove(skill);
        await _context.SaveChangesAsync();
        return true;
    }
}