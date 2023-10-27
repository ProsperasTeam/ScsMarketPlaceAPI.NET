using CurrencyService.Data;
using CurrencyService.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace CurrencyService.Controllers
{
    [ApiController]
    [Route("currency")] // Use the correct route path
    public class CurrencyController : ControllerBase
    {
        private readonly ILogger<CurrencyController> _logger;
        private readonly AppDbContext _context; // Replace 'YourDbContext' with your actual DbContext name

        public CurrencyController(ILogger<CurrencyController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet("{currencyid}", Name = "GetCurrency")]
        public IActionResult Get(int currencyid)
        {
            try
            {
                var currency = _context.currency.Find(currencyid);

                if (currency != null)
                {
                    return Ok(currency);
                }
                else
                {
                    return NotFound("Currency not found for the provided currencyid.");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while getting currency.");
                return StatusCode(500, new { error = ex.Message });
            }
        }

        [HttpGet]
        public IActionResult Getcurrency()
        {
            try
            {
                var currency = _context.currency.ToList();

                if (currency.Count > 0)
                {
                    return Ok(currency);
                }
                else
                {
                    return NotFound("No currency found.");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while getting currency.");
                return StatusCode(500, new { error = ex.Message });
            }
        }

        [HttpPost]
        public IActionResult CreateCurrency([FromBody] CurrencyModel currency)
        {
            try
            {
                _context.currency.Add(currency);
                _context.SaveChanges();

                return Ok(currency);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating a currency.");
                return StatusCode(500, new { error = ex.Message });
            }
        }

        [HttpPut]
        public IActionResult UpdateCurrency([FromBody] CurrencyModel currency)
        {
            try
            {
                if (_context.currency.Any(c => c.id == currency.id))
                {
                    _context.currency.Update(currency);
                    _context.SaveChanges();

                    return Ok(currency);
                }
                else
                {
                    return NotFound("Currency not found for the provided ID.");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating a currency.");
                return StatusCode(500, new { error = ex.Message });
            }
        }

        [HttpDelete("{currencyid}")]
        public IActionResult DeleteCurrency(int currencyid)
        {
            try
            {
                var currency = _context.currency.Find(currencyid);

                if (currency != null)
                {
                    _context.currency.Remove(currency);
                    _context.SaveChanges();
                    return Ok("Currency deleted successfully");
                }
                else
                {
                    return NotFound("Currency not found for the provided currencyid.");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while deleting a currency.");
                return StatusCode(500, new { error = ex.Message });
            }
        }
    }
}
