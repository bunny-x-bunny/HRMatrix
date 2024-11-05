using HRMatrix.Persistence.Contexts;
using Microsoft.AspNetCore.Mvc;

namespace HRMatrix.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VersionController : ControllerBase
{
    private readonly HRMatrixDbContext _context;

    public VersionController(HRMatrixDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetVersion()
    {
        var version = "1.0.9";
        return Ok(version);
    }

    [HttpGet("CheckConnection")]
    public IActionResult TestDbConnection() => _context.Database.CanConnect() ? Ok("OK") : Ok("Error");
}