using HRMatrix.Application.DTOs.Skill;
using HRMatrix.Application.Services.Interfaces.Directions;
using Microsoft.AspNetCore.Mvc;

namespace HRMatrix.Api.Controllers.Directions
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillsController : ControllerBase
    {
        private readonly ISkillService _skillService;

        public SkillsController(ISkillService skillService)
        {
            _skillService = skillService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSkills()
        {
            var skills = await _skillService.GetAllSkillsAsync();
            return Ok(skills);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSkillById(int id)
        {
            var skill = await _skillService.GetSkillByIdAsync(id);
            if (skill == null)
            {
                return NotFound();
            }
            return Ok(skill);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSkill([FromBody] CreateSkillDto skillDto)
        {
            if (skillDto == null)
            {
                return BadRequest("Invalid skill data.");
            }

            var createdSkillId = await _skillService.CreateSkillAsync(skillDto);
            return CreatedAtAction(nameof(GetSkillById), new { id = createdSkillId }, createdSkillId);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateSkill([FromBody] UpdateSkillDto skillDto)
        {
            if (skillDto == null)
            {
                return BadRequest("Invalid skill data.");
            }

            var updatedSkillId = await _skillService.UpdateSkillAsync(skillDto);
            return Ok(updatedSkillId);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSkill(int id)
        {
            var result = await _skillService.DeleteSkillAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
