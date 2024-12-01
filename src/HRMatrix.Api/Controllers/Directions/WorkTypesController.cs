using HRMatrix.Application.DTOs.WorkType;
using HRMatrix.Application.Services.Interfaces.Directions;
using Microsoft.AspNetCore.Mvc;

namespace HRMatrix.Api.Controllers.Directions;

[Route("api/[controller]")]
[ApiController]
public class WorkTypesController : ControllerBase
{
    private readonly IWorkTypeService _workTypeService;

    public WorkTypesController(IWorkTypeService workTypeService)
    {
        _workTypeService = workTypeService;
    }

    [HttpGet]
    [Obsolete("Unimplemented", true)]
    public async Task<IActionResult> GetAllWorkTypes()
    {
        //var workTypes = await _workTypeService.GetAllWorkTypesAsync();
        //return Ok(workTypes);
        throw new NotImplementedException();
    }

    [HttpGet("{id}")]
    [Obsolete("Unimplemented", true)]
    public async Task<IActionResult> GetWorkTypeById(int id)
    {
        //var workType = await _workTypeService.GetWorkTypeByIdAsync(id);
        //if (workType == null)
        //{
        //    return NotFound();
        //}
        //return Ok(workType);
        throw new NotImplementedException();
    }

    [HttpPost]
    public async Task<IActionResult> CreateWorkType([FromBody] CreateWorkTypeDto workTypeDto)
    {
        if (workTypeDto == null)
        {
            return BadRequest("Invalid work type data.");
        }

        var createdWorkTypeId = await _workTypeService.CreateWorkTypeAsync(workTypeDto);
        return CreatedAtAction(nameof(GetWorkTypeById), new { id = createdWorkTypeId }, createdWorkTypeId);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateWorkType([FromBody] UpdateWorkTypeDto workTypeDto)
    {
        if (workTypeDto == null)
        {
            return BadRequest("Invalid work type data.");
        }

        var updatedWorkTypeId = await _workTypeService.UpdateWorkTypeAsync(workTypeDto);
        if (updatedWorkTypeId == 0)
        {
            return NotFound();
        }

        return Ok(updatedWorkTypeId);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteWorkType(int id)
    {
        var result = await _workTypeService.DeleteWorkTypeAsync(id);
        if (!result)
        {
            return NotFound();
        }
        return NoContent();
    }
}