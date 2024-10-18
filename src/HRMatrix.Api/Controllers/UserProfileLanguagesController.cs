using HRMatrix.Application.DTOs.UserProfilesLanguages;
using HRMatrix.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HRMatrix.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserProfileLanguagesController : ControllerBase
    {
        private readonly IUserProfileLanguageService _userProfileLanguageService;

        public UserProfileLanguagesController(IUserProfileLanguageService userProfileLanguageService)
        {
            _userProfileLanguageService = userProfileLanguageService;
        }

        [HttpGet("{userProfileId}")]
        public async Task<IActionResult> GetUserProfileLanguages(int userProfileId)
        {
            var languages = await _userProfileLanguageService.GetUserProfileLanguagesAsync(userProfileId);
            return Ok(languages);
        }

        [HttpPost]
        public async Task<IActionResult> UpsertUserProfileLanguages([FromBody] CreateUserProfileLanguagesRequest languagesRequest)
        {
            var userProfileId = await _userProfileLanguageService.UpsertUserProfileLanguagesAsync(languagesRequest);
            return Ok(userProfileId);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserProfileLanguage(int id)
        {
            var result = await _userProfileLanguageService.DeleteUserProfileLanguageAsync(id);
            return result ? NoContent() : NotFound();
        }
    }

}
