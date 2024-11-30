using HRMatrix.IdentityService.Models;

namespace HRMatrix.Application.Services.Interfaces;

public interface IRoleRequestService
{
    Task<bool> SubmitRoleRequestAsync(int userId, string roleName);
    Task<IEnumerable<RoleRequest>> GetAllRequestsAsync();
    Task<RoleRequest?> GetRequestByIdAsync(int requestId);
    Task<bool> ApproveRequestAsync(int requestId);
    Task<bool> RejectRequestAsync(int requestId);
}