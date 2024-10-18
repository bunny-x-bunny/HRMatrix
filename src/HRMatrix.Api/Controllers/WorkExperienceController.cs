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
        private readonly IWorkExperienceService _workExperienceService;

        public WorkExperienceController(IWorkExperienceService workExperienceService)
        {
            _workExperienceService = workExperienceService;
        }

        [HttpGet("{userProfileId}/work-experiences")]
        public async Task<IActionResult> GetWorkExperiences(int userProfileId)
        {
            var workExperiences = await _workExperienceService.GetWorkExperiencesAsync(userProfileId);
            return Ok(workExperiences);
        }

        [HttpPost("work-experiences")]
        public async Task<IActionResult> AddOrUpdateWorkExperience([FromBody] CreateWorkExperienceDto workExperienceDto)
        {
            var workExperienceId = await _workExperienceService.AddOrUpdateWorkExperienceAsync(workExperienceDto);
            return Ok(workExperienceId);
        }

        [HttpDelete("work-experiences/{id}")]
        public async Task<IActionResult> DeleteWorkExperience(int id)
        {
            var result = await _workExperienceService.DeleteWorkExperienceAsync(id);
            if (!result) return NotFound();
            return NoContent();
        }
    }
}
