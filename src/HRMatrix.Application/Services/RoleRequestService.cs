using HRMatrix.Application.Services.Interfaces;
using HRMatrix.IdentityService.Models;
using HRMatrix.Persistence.Contexts;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace HRMatrix.Application.Services
{
    public class RoleRequestService : IRoleRequestService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly HRMatrixDbContext _context;

        public RoleRequestService(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager, HRMatrixDbContext context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
        }

        public async Task<bool> SubmitRoleRequestAsync(int userId, string roleName)
        {
            if (!await _roleManager.RoleExistsAsync(roleName))
                throw new ArgumentException("Role does not exist.");

            var existingRequest = await _context.RoleRequests
                .FirstOrDefaultAsync(r => r.UserId == userId && r.RoleName == roleName && r.Status == "Pending");

            if (existingRequest != null)
                throw new InvalidOperationException("A pending request for this role already exists.");

            var request = new RoleRequest
            {
                UserId = userId,
                RoleName = roleName,
                RequestedAt = DateTime.UtcNow,
                Status = "Pending"
            };

            _context.RoleRequests.Add(request);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<RoleRequest>> GetAllRequestsAsync()
        {
            return await _context.RoleRequests.Include(r => r.User).ToListAsync();
        }

        public async Task<RoleRequest?> GetRequestByIdAsync(int requestId)
        {
            return await _context.RoleRequests.Include(r => r.User).FirstOrDefaultAsync(r => r.Id == requestId);
        }

        public async Task<bool> ApproveRequestAsync(int requestId)
        {
            var request = await GetRequestByIdAsync(requestId);
            if (request == null || request.Status != "Pending")
                throw new InvalidOperationException("Request is not valid or has already been processed.");

            var user = request.User;
            if (user == null)
                throw new InvalidOperationException("User not found.");

            var result = await _userManager.AddToRoleAsync(user, request.RoleName);
            if (!result.Succeeded)
                throw new InvalidOperationException($"Failed to assign role: {string.Join(", ", result.Errors.Select(e => e.Description))}");

            request.Status = "Approved";
            request.ApprovedAt = DateTime.UtcNow;
            _context.RoleRequests.Update(request);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> RejectRequestAsync(int requestId)
        {
            var request = await GetRequestByIdAsync(requestId);
            if (request == null || request.Status != "Pending")
                throw new InvalidOperationException("Request is not valid or has already been processed.");

            request.Status = "Rejected";
            _context.RoleRequests.Update(request);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
