using Data.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace QuackQuack.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WordController : ControllerBase
{
    readonly IUnitOfWork _unitOfWork;
    readonly ILogger<WordController> _logger;

    public WordController(IUnitOfWork unitOfWork, ILogger<WordController> logger)
    {
        _unitOfWork = unitOfWork;
        _logger = logger;
    }

    [HttpGet("{word}")]
    public async Task<IActionResult> GetWordDefinition(string word)
    {
        var wordFound = await _unitOfWork.WordRepository.FirstOrDefaultAsync(x => x.Word == word);
        return Ok(wordFound);
    }
}
