using Microsoft.AspNetCore.Mvc;
using QuackQuack.Models;

namespace QuackQuack.Controllers;

[ApiController]
[Route("[controller]")]
public class BlogController : ControllerBase
{
    readonly ILogger<BlogController> _logger;

    public BlogController(ILogger<BlogController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllBlogPosts()
    {
        return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> AddBlogPost()
    {
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> UpdateBlogPost()
    {
        return Ok();
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteBlogPost()
    {
        return Ok();
    }
}
