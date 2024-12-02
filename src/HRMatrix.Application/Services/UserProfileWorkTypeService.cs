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

        //public async Task<List<UserProfileWorkTypeResponse>> GetUserProfileWorkTypes(UserProfile user) {
        //    var userProfileWorkTypes = await _context.UserProfileWorkTypes
        //        .Include(wt => wt.WorkType)
        //        .Where(wt => wt.UserProfileId == user.Id)
        //        .ToListAsync();
        //    return userProfileWorkTypes.Select(wt => new UserProfileWorkTypeResponse {
        //        WorkTypeId = wt.WorkTypeId,
        //        WorkTypeName = wt.WorkType.Name
        //    }).ToList();
        //}

        public async Task<int> CreateUserProfileWorkType(CreateUserProfileWorkTypeRequest workTypeDto, UserProfile user, bool withSave = false) {
            var workType = new UserProfileWorkType {
                UserProfileId = user.Id,
                WorkTypeId = workTypeDto.WorkTypeId
            };
            _context.UserProfileWorkTypes.Add(workType);
            if (withSave)
                await _context.SaveChangesAsync();
            return workType.Id;
        }

        public async Task<List<int>> UpsertUserProfileWorkTypes(List<CreateUserProfileWorkTypeRequest> workTypesDto, UserProfile user, bool withSave = false) {
            if (user.Id != 0) {
                var existingWorkTypes = await _context.UserProfileWorkTypes
                    .Where(wt => wt.UserProfileId == user.Id)
                    .ToListAsync();
                _context.UserProfileWorkTypes.RemoveRange(existingWorkTypes);
            }

            user.UserProfileWorkTypes = workTypesDto.Select(wt => new UserProfileWorkType {
                WorkTypeId = wt.WorkTypeId,
            }).ToList();

            if (withSave) {
                await _context.SaveChangesAsync();
                return user.UserProfileWorkTypes.Select(wt => wt.Id).ToList();
            } else {
                return Enumerable.Empty<int>().ToList();
            }
        }

        public async Task<bool> DeleteUserProfileWorkType(int userProfileWorkTypeId, bool withSave = false) {
            var workType = await _context.UserProfileWorkTypes.FindAsync(userProfileWorkTypeId);
            if (workType == null) return false;

            _context.UserProfileWorkTypes.Remove(workType);
            if (withSave)
                await _context.SaveChangesAsync();
            return true;
        }
    }
}
