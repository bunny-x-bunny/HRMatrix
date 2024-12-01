using HRMatrix.Application.DTOs.WorkExperiences;
using HRMatrix.Application.Services.Interfaces;
using HRMatrix.Domain.Entities;
using HRMatrix.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace HRMatrix.Application.Services
{
    public class UserProfileWorkExperienceService : IUserProfileWorkExperienceService {
        private readonly HRMatrixDbContext _context;

        public UserProfileWorkExperienceService(HRMatrixDbContext context)
        {
            _context = context;
        }

        public async Task<List<WorkExperienceResponseDto>> GetWorkExperiencesAsync(int userProfileId)
        {
            var workExperiences = await _context.WorkExperiences
                .Where(we => we.UserProfileId == userProfileId)
                .ToListAsync();

            return workExperiences.Select(we => new WorkExperienceResponseDto {
                Achievements = we.Achievements,
                CompanyName = we.CompanyName,
                EndDate = we.EndDate,
                Id = we.Id,
                Position = we.Position,
                StartDate = we.StartDate
            }).ToList();
        }

        public async Task<int> AddOrUpdateWorkExperienceAsync(CreateWorkExperienceDto workExperienceDto, bool withSave = false)
        {
            var workExperience = new WorkExperience {
                UserProfileId = workExperienceDto.UserProfileId,
                CompanyName = workExperienceDto.CompanyName,
                Position = workExperienceDto.Position,
                StartDate = workExperienceDto.StartDate,
                EndDate = workExperienceDto.EndDate,
                Achievements = workExperienceDto.Achievements
            };
            var userProfileId = workExperienceDto.UserProfileId;
            workExperience.UserProfileId = userProfileId;

            var existingExperience = await _context.WorkExperiences
                .FirstOrDefaultAsync(we => we.UserProfileId == userProfileId && we.CompanyName == workExperience.CompanyName);

            if (existingExperience != null)
            {
                existingExperience.Position = workExperience.Position;
                existingExperience.StartDate = workExperience.StartDate;
                existingExperience.EndDate = workExperience.EndDate;
                existingExperience.Achievements = workExperience.Achievements;
            }
            else
            {
                _context.WorkExperiences.Add(workExperience);
            }

            if(withSave)
                await _context.SaveChangesAsync();
            return workExperience.Id;
        }

        public async Task<bool> DeleteWorkExperienceAsync(int id, bool withSave = false)
        {
            var workExperience = await _context.WorkExperiences.FindAsync(id);
            if (workExperience == null) return false;

            _context.WorkExperiences.Remove(workExperience);
            if(withSave)
                await _context.SaveChangesAsync();
            return true;
        }
    }
}
