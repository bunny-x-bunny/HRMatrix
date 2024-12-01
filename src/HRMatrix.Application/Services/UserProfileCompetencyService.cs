using HRMatrix.Application.DTOs.Competency;
using HRMatrix.Application.DTOs.UserProfileCompetency;
using HRMatrix.Application.Services.Interfaces;
using HRMatrix.Persistence.Contexts;
using HRMatrix.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HRMatrix.Application.Services
{
    public class UserProfileCompetencyService : IUserProfileCompetencyService
    {
        private readonly HRMatrixDbContext _context;

        public UserProfileCompetencyService(HRMatrixDbContext context)
        {
            _context = context;
        }

        //public async Task<UserProfileCompetencyListResponse> GetUserProfileCompetenciesAsync(int userProfileId)
        //{
        //    var userProfileCompetencies = await _context.UserProfileCompetencies
        //        .Include(up => up.Competency)
        //        .Include(up => up.Competency.Translations)
        //        .Where(up => up.UserProfileId == userProfileId)
        //        .ToListAsync();

        //    var competencyResponses = userProfileCompetencies.Select(upCompetency => new UserProfileCompetencyResponse {
        //        CompetencyId = upCompetency.CompetencyId,
        //        CompetencyName = upCompetency.Competency.Name,
        //        ProficiencyLevel = upCompetency.ProficiencyLevel,
        //        Translations = upCompetency.Competency.Translations.Select(t => new CompetencyTranslationDto {
        //            Id = t.Id,
        //            LanguageCode = t.LanguageCode,
        //            Name = t.Name
        //        }).ToList()
        //    }).ToList();

        //    return new UserProfileCompetencyListResponse
        //    {
        //        UserProfileId = userProfileId,
        //        Competencies = competencyResponses
        //    };
        //}

        public async Task<int> UpsertUserProfileCompetenciesAsync(CreateUserProfileCompetenciesRequest competenciesRequest, bool withSave = false)
        {
            var userProfile = await _context.UserProfiles.FindAsync(competenciesRequest.UserProfileId);

            if (userProfile == null)
            {
                throw new Exception($"User profile with ID {competenciesRequest.UserProfileId} not found.");
            }

            var existingCompetencies = await _context.UserProfileCompetencies
                .Where(up => up.UserProfileId == competenciesRequest.UserProfileId)
                .ToListAsync();
            _context.UserProfileCompetencies.RemoveRange(existingCompetencies);

            var newCompetencies = competenciesRequest.Competencies.Select(competency => new UserProfileCompetency
            {
                UserProfileId = competenciesRequest.UserProfileId,
                CompetencyId = competency.CompetencyId,
                ProficiencyLevel = competency.ProficiencyLevel
            }).ToList();

            _context.UserProfileCompetencies.AddRange(newCompetencies);
            if (withSave)
                await _context.SaveChangesAsync();

            return competenciesRequest.UserProfileId;
        }

        public async Task<bool> DeleteUserProfileCompetencyAsync(int id, bool withSave = false)
        {
            var competency = await _context.UserProfileCompetencies.FindAsync(id);
            if (competency == null) return false;

            _context.UserProfileCompetencies.Remove(competency);
            if (withSave)
                await _context.SaveChangesAsync();
            return true;
        }
    }
}
