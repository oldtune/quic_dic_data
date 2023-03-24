using Microsoft.AspNetCore.Mvc;
using QuackQuack.Models;

namespace QuackQuack.Controllers;

[ApiController]
[Route("[controller]")]
public class PlatformController : ControllerBase
{
    readonly ILogger<PlatformController> _logger;

    public PlatformController(ILogger<PlatformController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllPlatform()
    {
        return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> GetPlatformDetail()
    {
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> UpdatePlatform()
    {
        return Ok();
    }

    [HttpDelete]
    public async Task<IActionResult> DeletePlatform()
    {
        return Ok();
    }
}
