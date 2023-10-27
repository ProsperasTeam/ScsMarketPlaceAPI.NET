using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;
using CountryService.Models; // Import your models namespace
using Microsoft.EntityFrameworkCore; // Import EF Core namespace
using System.Diagnostics.Metrics;
using CountryService.Data;

namespace CountryService.Controllers
{
    [ApiController]
    [Route("country")]
    public class CountryController : ControllerBase
    {
        private readonly ILogger<CountryController> _logger;
        private readonly AppDbContext _context;

        public CountryController(ILogger<CountryController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet("{countryid}", Name = "GetCountry")]
        public async Task<IActionResult> Get(int countryid)
        {
            try
            {
                var country = await _context.country.FirstOrDefaultAsync(c => c.id == countryid);

                if (country != null)
                {
                    return Ok(country);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting country");
                return StatusCode(500, new { error = ex.Message });
            }
        }



        [HttpGet(Name = "GetCountries")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var countries = await _context.country.ToListAsync();

                if (countries.Any())
                {
                    return Ok(countries);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting countries");
                return StatusCode(500, new { error = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Country country)
        {
            try
            {
                _context.country.Add(country);
                await _context.SaveChangesAsync();
                return CreatedAtRoute("GetCountry", new { countryid = country.id }, country);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error saving country");
                return StatusCode(500, new { error = ex.Message });
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Country country)
        {
            try
            {
                _context.Entry(country).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return Ok(country);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating country");
                return StatusCode(500, new { error = ex.Message });
            }
        }

        [HttpDelete("{countryid}")]
        public async Task<IActionResult> Delete(int countryid)
        {
            try
            {
                var country = await _context.country.FirstOrDefaultAsync(c => c.id == countryid);

                if (country != null)
                {
                    _context.country.Remove(country);
                    await _context.SaveChangesAsync();
                    return NoContent();
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting country");
                return StatusCode(500, new { error = ex.Message });
            }
        }
    }
}
