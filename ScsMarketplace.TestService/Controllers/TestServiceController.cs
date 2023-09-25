using Microsoft.AspNetCore.Mvc;

namespace ScsMarketplace.TestService.Controllers;

[ApiController]
[Route("[controller]")]
public class TestServiceController : ControllerBase
{
    private readonly ILogger<TestServiceController> _logger;

    public TestServiceController(ILogger<TestServiceController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "TestService")]
    public IActionResult Get()
    {
        
            try
            {
                var data = new { Message = "Hello, TestService!" };

                return Ok(data);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while processing the request.");
                return StatusCode(500, "An error occurred while processing the request.");
            }
        
    }
}

