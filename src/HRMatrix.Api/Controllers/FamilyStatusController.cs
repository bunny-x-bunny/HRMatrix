using HRMatrix.Application.DTOs.FamilyStatus;
using HRMatrix.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HRMatrix.Api.Controllers;

//[Route("api/[controller]")]
//[ApiController]
//public class FamilyStatusController : ControllerBase
//{
//    private readonly IFamilyStatusService _familyStatusService;

//    public FamilyStatusController(IFamilyStatusService familyStatusService)
//    {
//        _familyStatusService = familyStatusService;
//    }

//    [HttpGet("user/{userProfileId}")]
//    public async Task<IActionResult> GetAllFamilyStatusesForUserProfile(int userProfileId)
//    {
//        var statuses = await _familyStatusService.GetAllFamilyStatusesForUserProfileAsync(userProfileId);
//        return Ok(statuses);
//    }

//    [HttpGet("{id}/user/{userProfileId}")]
//    public async Task<IActionResult> GetFamilyStatusForUserProfile(int id, int userProfileId)
//    {
//        var status = await _familyStatusService.GetFamilyStatusForUserProfileByIdAsync(id, userProfileId);
//        if (status == null)
//        {
//            return NotFound();
//        }

//        return Ok(status);
//    }

//    [HttpPost("user/{userProfileId}")]
//    public async Task<IActionResult> CreateFamilyStatusForUserProfile(int userProfileId, [FromBody] CreateFamilyStatusDto familyStatusDto)
//    {
//        var createdStatus = await _familyStatusService.CreateFamilyStatusForUserProfileAsync(familyStatusDto, userProfileId);
//        return CreatedAtAction(nameof(GetFamilyStatusForUserProfile), new { id = createdStatus.Id, userProfileId = userProfileId }, createdStatus);
//    }

//    [HttpPut("{id}/user/{userProfileId}")]
//    public async Task<IActionResult> UpdateFamilyStatusForUserProfile(int id, int userProfileId, [FromBody] UpdateFamilyStatusDto familyStatusDto)
//    {
//        if (id != familyStatusDto.Id)
//        {
//            return BadRequest("ID mismatch.");
//        }

//        var updatedStatus = await _familyStatusService.UpdateFamilyStatusForUserProfileAsync(familyStatusDto, userProfileId);
//        if (updatedStatus == null)
//        {
//            return NotFound();
//        }

//        return Ok(updatedStatus);
//    }

//    [HttpDelete("{id}/user/{userProfileId}")]
//    public async Task<IActionResult> DeleteFamilyStatusForUserProfile(int id, int userProfileId)
//    {
//        var result = await _familyStatusService.DeleteFamilyStatusForUserProfileAsync(id, userProfileId);
//        if (!result)
//        {
//            return NotFound();
//        }

//        return NoContent();
//    }
//}