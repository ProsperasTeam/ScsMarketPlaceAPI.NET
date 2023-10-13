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

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AuthenticationService.Controllers.Authentication
{
   



    [Route("api/session")]
    [ApiController]
    public class SessionController : ControllerBase
    {
        public class AppSettings
        {
            public string ClaroSessionIdAPI { get; set; }
        }

        public class SessionValidationRequest
        {
            public string SessionId { get; set; }
        }

        public class SessionValidationResponse
        {
            public bool success { get; set; }
            public bool failure { get; set; }
            public string mensaje { get; set; }
        }

        public class ErrorResponse
        {
            public string Message { get; set; }
        }

        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<SessionController> _logger;
        private readonly IConfiguration _configuration;



        public SessionController(IHttpClientFactory httpClientFactory, ILogger<SessionController> logger, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
            _configuration = configuration;
        }

        [HttpPost("validate")]

        public async Task<IActionResult> ValidateSessionId([FromBody] SessionValidationRequest request)
        {
            var claroURL = _configuration["ClaroSessionIdAPI"];

            try
            {
                var sessionId = request.SessionId;

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

                    // Deserialize the JSON response
                    var responseObject = JsonSerializer.Deserialize<SessionValidationResponse>(responseContent);

                    if (responseObject.success)
                    {
                        return Ok(responseObject);
                    }
                    else
                    {
                        var errorResponse = new ErrorResponse
                        {
                            Message = responseObject.mensaje
                        };
                        return BadRequest(errorResponse);
                    }
                }
                else
                {
                    return BadRequest();
                }

            }
            catch (Exception ex)
            {
                // Handle exceptions and log as needed
                var errorResponse = new ErrorResponse
                {
                    Message = ex.Message
                };

                return StatusCode(500, errorResponse);
            }

        }
    }

}
