using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConsumerService.Data;
using ConsumerService.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ConsumerService.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    
    public class ConsumerController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly ILogger<ConsumerController> _logger;


        public ConsumerController(AppDbContext context, ILogger<ConsumerController> logger)
        {
            _context = context;
            _logger = logger;
        }


        [HttpPost]
        public IActionResult Post([FromBody] ConsumerModel data)
        {
            try
            {
                _logger.LogInformation($"data is {data}");
                _context.Consumers.Add(data);
                _context.SaveChanges();
                return Ok(data);
            } catch(Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }
    }
}

