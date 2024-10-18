using AutoMapper;
using HRMatrix.Application.DTOs.WorkExperiences;
using HRMatrix.Application.Services.Interfaces;
using HRMatrix.Domain.Entities;
using HRMatrix.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace HRMatrix.Application.Services
{
    public class WorkExperienceService : IWorkExperienceService
    {
        private readonly HRMatrixDbContext _context;
        private readonly IMapper _mapper;

        public WorkExperienceService(HRMatrixDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<WorkExperienceResponseDto>> GetWorkExperiencesAsync(int userProfileId)
        {
            var workExperiences = await _context.WorkExperiences
                .Where(we => we.UserProfileId == userProfileId)
                .ToListAsync();

            return _mapper.Map<List<WorkExperienceResponseDto>>(workExperiences);
        }

        public async Task<int> AddOrUpdateWorkExperienceAsync(CreateWorkExperienceDto workExperienceDto)
        {
            var workExperience = _mapper.Map<WorkExperience>(workExperienceDto);
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

            await _context.SaveChangesAsync();
            return workExperience.Id;
        }

        public async Task<bool> DeleteWorkExperienceAsync(int id)
        {
            var workExperience = await _context.WorkExperiences.FindAsync(id);
            if (workExperience == null) return false;

            _context.WorkExperiences.Remove(workExperience);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
