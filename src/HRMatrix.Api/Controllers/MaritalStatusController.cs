using HRMatrix.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HRMatrix.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaritalStatusController : ControllerBase
    {
        private readonly IMaritalStatusService _maritalStatusService;

        public MaritalStatusController(IMaritalStatusService maritalStatusService)
        {
            _maritalStatusService = maritalStatusService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMaritalStatuses()
        {
            var statuses = await _maritalStatusService.GetAllMaritalStatusesAsync();
            return Ok(statuses);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMaritalStatusById(int id)
        {
            var status = await _maritalStatusService.GetMaritalStatusByIdAsync(id);
            if (status == null)
            {
                return NotFound();
            }
            return Ok(status);
        }

        //[HttpPost]
        //public async Task<IActionResult> CreateMaritalStatus([FromBody] MaritalStatusDto maritalStatusDto)
        //{
        //    if (maritalStatusDto == null)
        //    {
        //        return BadRequest("Invalid data.");
        //    }

        //    var createdStatus = await _maritalStatusService.CreateMaritalStatusAsync(maritalStatusDto);
        //    return CreatedAtAction(nameof(GetMaritalStatusById), new { id = createdStatus.Id }, createdStatus);
        //}

        //[HttpPut("{id}")]
        //public async Task<IActionResult> UpdateMaritalStatus(int id, [FromBody] MaritalStatusDto maritalStatusDto)
        //{
        //    if (id != maritalStatusDto.Id)
        //    {
        //        return BadRequest("ID mismatch.");
        //    }

        //    var updatedStatus = await _maritalStatusService.UpdateMaritalStatusAsync(maritalStatusDto);
        //    if (updatedStatus == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(updatedStatus);
        //}

        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteMaritalStatus(int id)
        //{
        //    var result = await _maritalStatusService.DeleteMaritalStatusAsync(id);
        //    if (!result)
        //    {
        //        return NotFound();
        //    }

        //    return NoContent();
        //}
    }
}
