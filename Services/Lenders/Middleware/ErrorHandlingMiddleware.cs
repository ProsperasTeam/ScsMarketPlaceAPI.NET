using Lenders.Common;
using Lenders.Models;
using System.Text.Json;

namespace Lenders.Middleware
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandlingMiddleware> _logger;

        public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }      

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unhandled exception occurred.");
                context.Response.ContentType = "application/json";

                if (ex.Message == Constants.NotAuthorized)
                {
                    ErrorResponse errResponse = new ErrorResponse
                    {
                        Message = ex.Message,
                        Detail = "User is not authorized to perform this action.",
                        StatusCode = StatusCodes.Status401Unauthorized,
                        ErrorCode = "401"
                    };

                    var jsonRes = JsonSerializer.Serialize(errResponse);                   
                    context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    await context.Response.WriteAsync(jsonRes);

                }
                else
                {
                    var errorResponse = new ErrorResponse
                    {
                        Message = "An error occurred.",
                        Detail = ex.Message,
                        StatusCode = StatusCodes.Status500InternalServerError,
                        ErrorCode = "500"
                    };

                    var jsonResponse = JsonSerializer.Serialize(errorResponse);
                    context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                    await context.Response.WriteAsync(jsonResponse);

                }
               
            }
        }
    }
}
