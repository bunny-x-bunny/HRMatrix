using HRMatrix.Application.DTOs.WorkExperiences;
using HRMatrix.Application.Services.Interfaces;
using HRMatrix.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace HRMatrix.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WorkExperienceController : ControllerBase
    {
        private readonly IUserProfileWorkExperienceService _workExperienceService;

        public WorkExperienceController(IUserProfileWorkExperienceService workExperienceService)
        {
            _workExperienceService = workExperienceService;
        }

        [HttpGet("{userProfileId}/work-experiences")]
        [Obsolete("Unimplemented", true)]
        public async Task<IActionResult> GetWorkExperiences(int userProfileId)
        {
            //var workExperiences = await _workExperienceService.GetWorkExperiencesAsync(userProfileId);
            //return Ok(workExperiences);
            throw new NotImplementedException();
        }

        [HttpPost("work-experiences")]
        public async Task<IActionResult> AddOrUpdateWorkExperience([FromBody] CreateWorkExperienceDto workExperienceDto)
        {
            var workExperienceId = await _workExperienceService.AddOrUpdateWorkExperienceAsync(workExperienceDto, true);
            return Ok(workExperienceId);
        }

        [HttpDelete("work-experiences/{id}")]
        public async Task<IActionResult> DeleteWorkExperience(int id)
        {
            var result = await _workExperienceService.DeleteWorkExperienceAsync(id, true);
            if (!result) return NotFound();
            return NoContent();
        }
    }
}
