using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Microsoft.EntityFrameworkCore;
using AuthenticationService.Models;
using AuthenticationService.Persistence;
using System.Security.Cryptography;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AuthenticationService.Controllers.Authentication
{

    [Route("api/session")]
    [ApiController]
    public class SessionController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<SessionController> _logger;
        private readonly IConfiguration _configuration;
        private readonly AppDbContext _dbContext;


        public SessionController(IHttpClientFactory httpClientFactory, ILogger<SessionController> logger, IConfiguration configuration, AppDbContext dbContext)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
            _configuration = configuration;
            _dbContext = dbContext;
        }

        [HttpPost("lookuporregister")]
        public async Task<IActionResult> LookupOrRegister([FromBody] SessionValidationRequest request)
        {
            var sessionId = request.SessionId;
            var apiK = Request.Headers["x-API-KEY"].ToString();
            //var apiK = "53788FFB-B0C2-48C7-929F-7130C2A52128";
            _logger.LogInformation($"apiK = {apiK}");

            if (string.IsNullOrEmpty(apiK))
            {
                _logger.LogInformation("No API key supplied");
                return StatusCode(401, "No API key supplied. Not authorized");
            }

            int? orgId = await DetermineOrganizationId(apiK);

            switch (orgId)
            {
                case 1:
                    // Handle the logic for organization 1
                    return StatusCode(500, "User not valid for org 1.");

                case 2:
                    // Handle the logic for organization 2 (Claro360)
                    var responseFromClaroApi = await ValidateSessionIdAgainstClaroApi(sessionId);
                    if (responseFromClaroApi != null && responseFromClaroApi.success)
                    {
                        // Authentication against ClaroAPI succeeded
                        return Ok(responseFromClaroApi);
                    }

                    // Authentication against ClaroAPI failed
                    return StatusCode(500, "User not found from vendor for sessionid.");

                case 3:
                    // Handle the logic for organization 3 (Bambu)
                    // Implement the logic for Bambu authentication here
                    break;

                case 4:
                    // Handle the logic for organization 4 (Prosperas)
                    var responseFromProsperas = await ValidateSessionIdAgainstProsperas(sessionId);
                    if (responseFromProsperas != null)
                    {
                        // Authentication against the database succeeded
                        return Ok(responseFromProsperas);
                    }

                    // Authentication against Prosperas failed
                    return StatusCode(500, "User not found from Prosperas for sessionid.");

                default:
                    // Handle the default case (e.g., Claro or other organizations)
                    // Implement the logic for the default organization here
                    break;
            }

            var errorResponse = new SessionValidationErrorResponse
            {
                Message = "User not found"
            };

            return StatusCode(500, errorResponse);
        }



        private async Task<SessionValidationResponse?> ValidateSessionIdAgainstClaroApi(string sessionId)
        {
            var claroURL = _configuration["ClaroSessionIdAPI"];

            var httpClient = _httpClientFactory.CreateClient();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var requestData = new
            {
                sessionId
            };

            var jsonRequest = JsonSerializer.Serialize(requestData);
            var response = await httpClient.PostAsync(claroURL, new StringContent(jsonRequest, System.Text.Encoding.UTF8, "application/json"));

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<SessionValidationResponse>(responseContent);
            }

            return null; // Return null if the request fails
        }

        private async Task<User?> ValidateSessionIdAgainstProsperas(string sessionId)
        {
            var user = await _dbContext.user.FirstOrDefaultAsync(u => u.sessionid == sessionId);

            if (user != null )
            {
                return user;
            }
            return null;
        }

        private async Task<int?> DetermineOrganizationId(string apiK)
        {
            var organization = await _dbContext.org.FirstOrDefaultAsync(o => o.authorizationkey == apiK);

            if (organization != null)
            {
                // Organization found, return its ID
                _logger.LogCritical($"org id is ====> {organization.id}");
                return organization.id;
            }

            // Organization not found
            return null;
        }



    }



}
