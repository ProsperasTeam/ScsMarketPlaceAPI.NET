using Microsoft.AspNetCore.Mvc;
using AuthenticationService.Models;
using AuthenticationService.Services;

namespace AuthenticationService.Controllers;

[ApiController]
[Route("[controller]")]
public class ExampleController : ControllerBase
{

    private readonly ILogger<ExampleController> _logger;

    private readonly IMessageProducer _messageProducer;

    // In-Memory DB Test

    public static readonly List<ExampleModel> _examples = new();

    public ExampleController(ILogger<ExampleController> logger, IMessageProducer messageProducer)
    {
        _logger = logger;
        _messageProducer = messageProducer;
    }

    [HttpPost]
    public IActionResult CreatingExample(ExampleModel newExample)
    {
        if (!ModelState.IsValid) return BadRequest();

        _examples.Add(newExample);
        _messageProducer.SendingMessage(newExample);

        return Ok();
    } 
}

