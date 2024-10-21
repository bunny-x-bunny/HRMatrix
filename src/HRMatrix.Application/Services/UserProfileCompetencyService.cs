using AutoMapper;
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
        private readonly IMapper _mapper;

        public UserProfileCompetencyService(HRMatrixDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<UserProfileCompetencyListResponse> GetUserProfileCompetenciesAsync(int userProfileId)
        {
            var userProfileCompetencies = await _context.UserProfileCompetencies
                .Include(up => up.Competency)
                .Include(up => up.Competency.Translations)
                .Where(up => up.UserProfileId == userProfileId)
                .ToListAsync();

            var competencyResponses = userProfileCompetencies.Select(upCompetency => new UserProfileCompetencyResponse
            {
                CompetencyId = upCompetency.CompetencyId,
                CompetencyName = upCompetency.Competency.Name,
                ProficiencyLevel = upCompetency.ProficiencyLevel,
                Translations = _mapper.Map<List<CompetencyTranslationDto>>(upCompetency.Competency.Translations)
            }).ToList();

            return new UserProfileCompetencyListResponse
            {
                UserProfileId = userProfileId,
                Competencies = competencyResponses
            };
        }

        public async Task<int> UpsertUserProfileCompetenciesAsync(CreateUserProfileCompetenciesRequest competenciesRequest)
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

            await _context.UserProfileCompetencies.AddRangeAsync(newCompetencies);
            await _context.SaveChangesAsync();

            return competenciesRequest.UserProfileId;
        }

        public async Task<bool> DeleteUserProfileCompetencyAsync(int id)
        {
            var competency = await _context.UserProfileCompetencies.FindAsync(id);
            if (competency == null) return false;

            _context.UserProfileCompetencies.Remove(competency);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
