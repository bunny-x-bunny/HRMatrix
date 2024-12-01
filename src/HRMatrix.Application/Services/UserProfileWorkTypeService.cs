using HRMatrix.Application.DTOs.UserProfileWorkType;
using HRMatrix.Application.Services.Interfaces;
using HRMatrix.Domain.Entities;
using HRMatrix.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace HRMatrix.Application.Services
{
    public class UserProfileWorkTypeService : IUserProfileWorkTypeService {
        private readonly HRMatrixDbContext _context;

        public UserProfileWorkTypeService(HRMatrixDbContext context) {
            _context = context;
        }

        public async Task<List<UserProfileWorkTypeResponse>> GetAllWorkTypesForUserProfileAsync(UserProfile user) {
            var userProfileWorkTypes = await _context.UserProfileWorkTypes
                .Include(wt => wt.WorkType)
                .Where(wt => wt.UserProfileId == user.Id)
                .ToListAsync();
            return userProfileWorkTypes.Select(wt => new UserProfileWorkTypeResponse {
                WorkTypeId = wt.WorkTypeId,
                WorkTypeName = wt.WorkType.Name
            }).ToList();
        }

        public async Task<int> CreateWorkTypeForUserProfileAsync(CreateUserProfileWorkTypeRequest workTypeDto, UserProfile user, bool withSave = false) {
            var workType = new UserProfileWorkType {
                UserProfileId = user.Id,
                WorkTypeId = workTypeDto.WorkTypeId
            };
            _context.UserProfileWorkTypes.Add(workType);
            if (withSave)
                await _context.SaveChangesAsync();
            return workType.Id;
        }

        public async Task<List<int>> UpsertWorkTypesForUserProfileAsync(CreateUserProfileWorkTypesRequest workTypesDto, bool withSave = false) {
            var userProfile = await _context.UserProfiles.FindAsync(workTypesDto.UserProfileId);
            if (userProfile == null) {
                throw new Exception($"User profile with ID {workTypesDto.UserProfileId} not found.");
            }

            var existingWorkTypes = await _context.UserProfileWorkTypes
                .Where(wt => wt.UserProfileId == workTypesDto.UserProfileId)
                .ToListAsync();
            _context.UserProfileWorkTypes.RemoveRange(existingWorkTypes);

            var newWorkTypes = workTypesDto.WorkTypes.Select(wt => new UserProfileWorkType {
                UserProfileId = workTypesDto.UserProfileId,
                WorkTypeId = wt.WorkTypeId,
            }).ToList();

            _context.UserProfileWorkTypes.AddRange(newWorkTypes);

            if (withSave) {
                await _context.SaveChangesAsync();
                return userProfile.UserProfileWorkTypes.Select(wt => wt.Id).ToList();
            } else {
                return [];
            }
        }

        public async Task<bool> DeleteWorkTypeForUserProfileAsync(int userProfileWorkTypeId, bool withSave = false) {
            var workType = await _context.UserProfileWorkTypes.FindAsync(userProfileWorkTypeId);
            if (workType == null) return false;

            _context.UserProfileWorkTypes.Remove(workType);
            if (withSave)
                await _context.SaveChangesAsync();
            return true;
        }
    }
}
