using Microsoft.AspNetCore.Mvc;

namespace QuackQuack.Controllers;

[ApiController]
[Route("[controller]")]
public class ProfileController : ControllerBase
{
    ILogger<ProfileController> _logger;
    public ProfileController(ILogger<ProfileController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public async Task<IActionResult> GetProfile()
    {
        return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> UpdateProfile(Dictionary<string, string> profiles)
    {
        return Ok();
    }
}
