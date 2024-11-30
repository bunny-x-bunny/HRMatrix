using HRMatrix.Application.Services.Interfaces;
using HRMatrix.IdentityService.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HRMatrix.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RoleRequestController : ControllerBase
    {
        private readonly IRoleRequestService _roleRequestService;
        private readonly UserManager<ApplicationUser> _userManager;

        public RoleRequestController(IRoleRequestService roleRequestService, UserManager<ApplicationUser> userManager)
        {
            _roleRequestService = roleRequestService;
            _userManager = userManager;
        }

        [HttpPost("request-role")]
        public async Task<IActionResult> RequestRole([FromBody] string roleName)
        {
            var userName = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userName))
                return NotFound("User not found");
            var user = await _userManager.FindByNameAsync(userName);
            if (user == null)
                return NotFound("User not found");

            try
            {
                var success = await _roleRequestService.SubmitRoleRequestAsync(user.Id, roleName);
                if (success)
                    return Ok(new { message = $"Your request for the role {roleName} has been submitted." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }

            return BadRequest("Failed to submit role request.");
        }

        [HttpGet("role-requests")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetRoleRequests()
        {
            var requests = await _roleRequestService.GetAllRequestsAsync();
            return Ok(requests.Select(r => new
            {
                r.Id,
                r.UserId,
                r.User.UserName,    
                r.User.LastName,
                r.RoleName,
                r.RequestedAt,
                r.Status,
                r.ApprovedAt
            }));
        }

        [HttpPost("approve-role/{requestId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> ApproveRoleRequest(int requestId)
        {
            try
            {
                var success = await _roleRequestService.ApproveRequestAsync(requestId);
                if (success)
                    return Ok(new { message = "Role request approved successfully." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }

            return BadRequest("Failed to approve role request.");
        }

        [HttpPost("reject-role/{requestId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> RejectRoleRequest(int requestId)
        {
            try
            {
                var success = await _roleRequestService.RejectRequestAsync(requestId);
                if (success)
                    return Ok(new { message = "Role request rejected successfully." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }

            return BadRequest("Failed to reject role request.");
        }
    }
}
