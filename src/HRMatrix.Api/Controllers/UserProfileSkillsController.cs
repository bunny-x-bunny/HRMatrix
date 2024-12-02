using HRMatrix.Application.DTOs.UserProfileSkills;
using HRMatrix.Application.Services;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class UserProfileSkillsController : ControllerBase
{
    private readonly IUserProfileSkillService _userProfileSkillService;

    public UserProfileSkillsController(IUserProfileSkillService userProfileSkillService)
    {
        _userProfileSkillService = userProfileSkillService;
    }

    [HttpGet("{userProfileId}")]
    [Obsolete("Unimplemented", true)]
    public async Task<IActionResult> GetUserProfileSkills(int userProfileId) {
        //var skills = await _userProfileSkillService.GetUserProfileSkillsAsync(userProfileId);
        //return Ok(skills);
        throw new NotImplementedException();
    }

    [HttpPost]
    [Obsolete("Unimplemented", true)]
    public async Task<IActionResult> UpsertUserProfileSkills([FromBody] CreateUserProfileSkillsRequest skillsRequest)
    {
        //var userProfileId = await _userProfileSkillService.UpsertUserProfileSkillsAsync(skillsRequest.Skills, userProfile, true);
        //return Ok(userProfileId);
        throw new NotImplementedException();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUserProfileSkill(int id)
    {
        var result = await _userProfileSkillService.DeleteUserProfileSkillAsync(id, true);
        return result ? NoContent() : NotFound();
    }
}