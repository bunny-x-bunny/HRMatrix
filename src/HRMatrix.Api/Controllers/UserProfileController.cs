using AutoMapper;
using HRMatrix.Application.DTOs.UserProfile;
using HRMatrix.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class UserProfileController : ControllerBase
{
    private readonly IUserProfileService _userProfileService;
    private readonly IFileStorageService _fileStorageService;
    private readonly IMapper _mapper;

    public UserProfileController(IUserProfileService userProfileService, IMapper mapper, IFileStorageService fileStorageService)
    {
        _userProfileService = userProfileService;
        _mapper = mapper;
        _fileStorageService = fileStorageService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllUserProfiles()
    {
        var profiles = await _userProfileService.GetAllUserProfilesAsync();
        return Ok(profiles);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserProfileById(int id)
    {
        var profile = await _userProfileService.GetUserProfileByIdAsync(id);
        if (profile == null)
        {
            return NotFound();
        }

        return Ok(profile);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateUserProfile(
        [FromBody] CreateUserProfileDto createUserProfileDto)
    {
        if (createUserProfileDto == null)
        {
            return BadRequest("Invalid profile data.");
        }

        var userProfileDto = _mapper.Map<CreateUserProfileDto>(createUserProfileDto);
        var createdProfileId = await _userProfileService.CreateUserProfileAsync(userProfileDto);
        return Ok(createdProfileId);
    }

    [HttpPost("UploadDocuments")]
    public async Task<IActionResult> UploadFiles(int profileId,
        IFormFile? profilePhoto, IFormFile? profileVideo)
    {
        var photoFileName = string.Empty;
        var videoFileName = string.Empty;
        if (profilePhoto != null)
            photoFileName = await _fileStorageService.UploadFileAsync(profilePhoto, "profile-photos");

        if (profileVideo != null)
            videoFileName = await _fileStorageService.UploadFileAsync(profileVideo, "profile-videos");

        await _userProfileService.UpdateProfileDocuments(profileId, photoFileName, videoFileName);

        return Ok(new { Message = "Files uploaded successfully." });
    }

    [HttpPut]
    public async Task<IActionResult> UpdateUserProfile([FromBody] UpdateUserProfileDto userProfileDto)
    {

        var updatedProfile = await _userProfileService.UpdateUserProfileAsync(userProfileDto);
        if (updatedProfile == null)
        {
            return NotFound();
        }

        return Ok(updatedProfile);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUserProfile(int id)
    {
        var result = await _userProfileService.DeleteUserProfileAsync(id);
        if (!result)
        {
            return NotFound();
        }

        return NoContent();
    }
}
