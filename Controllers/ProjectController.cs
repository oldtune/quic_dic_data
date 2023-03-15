using Microsoft.AspNetCore.Mvc;
using QuackQuack.Models;

namespace QuackQuack.Controllers;

[ApiController]
[Route("[controller]")]
public class ProjectController : ControllerBase
{
    ILogger<ProjectController> _logger;

    public ProjectController(ILogger<ProjectController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public async Task<IActionResult> GetProject()
    {
        return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> AddProject(IEnumerable<ProjectPatch> projects)
    {
        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(string id, ProjectPatch project)
    {
        return Ok();
    }

    public async Task<IActionResult> DeleteProject(IEnumerable<int> projectIds)
    {
        return Ok();
    }
}
