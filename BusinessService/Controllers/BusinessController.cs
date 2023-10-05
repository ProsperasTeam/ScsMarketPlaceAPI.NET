using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BusinessService.Models.Business;
using BusinessService.Data;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BusinessService.Controllers.Business
{

    [Route("api/business")]
    [ApiController]
    public class BusinessController : ControllerBase

    {

        private readonly AppDbContext _context;
        private readonly ILogger<BusinessController> _logger;

        public BusinessController(AppDbContext context, ILogger<BusinessController> logger)
        {
            _context = context;
            _logger = logger;
        }
        // GET: /<controller>/
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BusinessModel>>> GetBusiness()
        {
            var business = await _context.Business.ToListAsync();
            _logger.LogInformation($"api response {business}");
            return Ok();
        }

        [HttpPost]
        public IActionResult Post([FromBody] BusinessModel data)
        {
            try
            {
                _logger.LogInformation($"data is {data}");
                _context.Business.Add(data);
                _context.SaveChanges();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }
    }
}

