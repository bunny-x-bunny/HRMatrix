﻿using AutoMapper;
using HRMatrix.Application.DTOs.UserProfile;
using HRMatrix.Application.Services.Interfaces;
using HRMatrix.IdentityService.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

[Route("api/[controller]")]
[ApiController]
public class UserProfileController : ControllerBase
{
    private readonly IUserProfileService _userProfileService;
    private readonly IFileStorageService _fileStorageService;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IMapper _mapper;

    public UserProfileController(IUserProfileService userProfileService, IMapper mapper, IFileStorageService fileStorageService, UserManager<ApplicationUser> userManager)
    {
        _userProfileService = userProfileService;
        _mapper = mapper;
        _fileStorageService = fileStorageService;
        _userManager = userManager;
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

    [HttpGet("MyProfiles")]
    public async Task<IActionResult> GetMyProfiles()
    {
        if (!User.Identity!.IsAuthenticated)
        {
            return Unauthorized("Token has expired or is invalid");
        }
        var userName = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (string.IsNullOrEmpty(userName))
            return NotFound("User not found");

        var user = await _userManager.FindByNameAsync(userName);
        if (user == null)
            return NotFound("User not found");
        var profiles = await _userProfileService.GetUserProfileByAspNetUserId(user.Id);
        if (profiles == null)
        {
            return NotFound();
        }

        return Ok(profiles);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> CreateUserProfile(
        [FromBody] CreateUserProfileDto createUserProfileDto)
    {
        if (createUserProfileDto == null)
        {
            return BadRequest("Invalid profile data.");
        }

        if (!User.Identity!.IsAuthenticated)
        {
            return Unauthorized("Token has expired or is invalid");
        }
        var userName = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (string.IsNullOrEmpty(userName))
            return NotFound("User not found");

        var user = await _userManager.FindByNameAsync(userName);
        if (user == null)
            return NotFound("User not found");

        var userProfileDto = _mapper.Map<CreateUserProfileDto>(createUserProfileDto);
        var createdProfileId = await _userProfileService.CreateUserProfileAsync(userProfileDto, user.Id);
        return Ok(createdProfileId);
    }

    [HttpPost("UploadDocuments")]
    [Authorize]
    public async Task<IActionResult> UploadFiles(int profileId,
        IFormFile? profilePhoto, IFormFile? profileVideo)
    {
        var photoFileName = string.Empty;
        var videoFileName = string.Empty;
        var gifUrl = string.Empty;

        if (profilePhoto != null)
        {
            photoFileName = await _fileStorageService.UploadFileAsync(profilePhoto, "profile-photos");
        }

        if (profileVideo != null)
        {
            videoFileName = await _fileStorageService.UploadFileAsync(profileVideo, "profile-videos");

            // Создаем GIF из первых 4 секунд видео и загружаем его
            var gifFilePath = await _fileStorageService.CreateGifFromVideo(videoFileName, "/var/www/uploads/profile-gifs");
            gifUrl = await _fileStorageService.UploadGifAsync(gifFilePath, "profile-gifs");
        }

        await _userProfileService.UpdateProfileDocuments(profileId, photoFileName, videoFileName);

        return Ok(new { Message = "Files uploaded successfully.", GifUrl = gifUrl });
    }

    [HttpPut]
    [Authorize]
    public async Task<IActionResult> UpdateUserProfile([FromBody] UpdateUserProfileDto userProfileDto)
    {
        if (!User.Identity!.IsAuthenticated)
        {
            return Unauthorized("Token has expired or is invalid");
        }
        var userName = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (string.IsNullOrEmpty(userName))
            return NotFound("User not found");

        var user = await _userManager.FindByNameAsync(userName);
        if (user == null)
            return NotFound("User not found");

        var updatedProfile = await _userProfileService.UpdateUserProfileAsync(userProfileDto, user.Id);
        if (updatedProfile == null)
        {
            return NotFound();
        }

        return Ok(updatedProfile);
    }
    
    [HttpDelete("{id}")]
    [Authorize]
    public async Task<IActionResult> DeleteUserProfile(int id)
    {
        var result = await _userProfileService.DeleteUserProfileAsync(id);
        if (!result)
        {
            return NotFound();
        }

        return NoContent();
    }

    [HttpGet("search")]
    [AllowAnonymous]
    public async Task<IActionResult> SearchUserProfiles(
        [FromQuery] string query = null,
        int limit = 10,
        [FromQuery] List<int> categoryId = null,
        [FromQuery] List<int> specialtyId = null,
        [FromQuery] List<int> locationId = null,
        [FromQuery] List<int> workTypeId = null,
        int page = 1,
        int pageSize = 10)
    {
        var result = await _userProfileService.SearchUserProfilesAsync(query, limit, categoryId, specialtyId, locationId, workTypeId, page, pageSize);
        return Ok(result);
    }
}
