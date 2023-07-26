using Microsoft.AspNetCore.Mvc;

namespace QuackQuack.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WordController : ControllerBase
{
    ILogger<WordController> _logger;

    public WordController(ILogger<WordController> logger)
    {
    }

    [HttpGet("{word}")]
    public IActionResult GetWordDefinition(string word)
    {
        var wordDef = new
        {
            definition = "greeting",
            word = "hello"
        };

        return Ok(wordDef);
    }
}
