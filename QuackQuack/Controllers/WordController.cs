using System.Text.Json;
using System.Text.Json.Serialization;
using AutoMapper;
using Data.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace QuackQuack.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WordController : ControllerBase
{
    readonly IUnitOfWork _unitOfWork;
    readonly ILogger<WordController> _logger;
    readonly IMapper _mapper;

    public WordController(IUnitOfWork unitOfWork,
    ILogger<WordController> logger,
    IMapper mapper)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _logger = logger;
    }

    [HttpGet("{word}")]
    public async Task<IActionResult> GetWordDefinition(string word)
    {
        var findResult = await _unitOfWork.WordRepository.FindFullDefinition(word);
        if (findResult.Ok)
        {
            return Ok(_mapper.Map<WordResponse>(findResult.Unwrap()));
        }

        return BadRequest(findResult.GetError());
    }
}
