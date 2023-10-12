using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ScsMarketplace.API.Models.Account;
using ScsMarketplace.API.Persistence;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ScsMarketplace.API.Controllers.Accounts
{

    // [Authorize]    
    [ApiController]
    [Route("api/accounts")]
    public class AccountController : ControllerBase

    {

        private readonly AppDbContext _context;
        private readonly ILogger<AccountController> _logger;

        public AccountController(AppDbContext context, ILogger<AccountController> logger)
        {
            _context = context;
            _logger = logger;
        }
        // GET: /<controller>/
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AccountModel>>> GetAccounts()
        {
            // var accounts = await _context.account.ToListAsync();
            // _logger.LogInformation($"api response {accounts}");
            // return Ok(accounts);
            return Ok();
        }
    }
}

