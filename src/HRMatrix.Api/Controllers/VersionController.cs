using Microsoft.AspNetCore.Mvc;

namespace HRMatrix.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VersionController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetVersion()
        {
            var version = "1.0.6";
            return Ok(version);
        }
    }
}
