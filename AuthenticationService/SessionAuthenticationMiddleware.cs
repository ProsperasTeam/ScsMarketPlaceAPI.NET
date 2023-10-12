using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen; 
using AuthenticationService.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

public class SessionAuthenticationMiddleware
{
    private readonly RequestDelegate _next;

    public SessionAuthenticationMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        // Get the session ID from the HttpContext (you should adapt this based on your session management)
        // string sessionId = context.Session.GetString("SessionId"); // Assuming you're using sessions
    

        if (context.Request.Headers.TryGetValue("SessionId", out var sessionId))
        {
            // Use var to declare a variable of type AppDbContext
            // var dbContext = context.RequestServices.GetRequiredService<AppDbContext>();
            // Trim and remove any unwanted characters from the session ID
            var sessionIdString = sessionId.ToString();

            // Query the database to retrieve the user based on the session ID
            // var user = dbContext.Users.FirstOrDefault(u => u.SessionId == sessionId);

            // if (user != null)
            // {
            //     // User found, you can perform actions or set user-related information in the HttpContext here
           
            // }
        }
        else
        {
            // If session is not valid, return unauthorized response
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
        }
    }

    private bool IsSessionValid(string sessionId)
    {
        // Implement your logic to check if the session ID is valid
        // For example, you might have a list of active sessions in memory or a database
        // and you can check if the provided session ID is in the list.

        // Replace this with your actual logic
        var activeSessions = new[] { "session123", "session456" };
        return Array.Exists(activeSessions, s => s == sessionId);
    }
}

public static class SessionAuthenticationMiddlewareExtensions
{
    public static IApplicationBuilder UseSessionAuthentication(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<SessionAuthenticationMiddleware>();
    }
}



public class SessionAuthenticationAttribute : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        // Apply the SessionAuthenticationMiddleware logic here
        // For example, check the session and perform authentication

        base.OnActionExecuting(context);
    }
}


// Create a custom OperationFilter to add SessionId as a parameter
public class AddSessionIdHeaderParameter : IOperationFilter
{
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        // Add SessionId as a header parameter
        operation.Parameters.Add(new OpenApiParameter
        {
            Name = "SessionId",
            In = ParameterLocation.Header,
            Description = "Session ID",
            Required = false, // Modify as needed
            Schema = new OpenApiSchema
            {
                Type = "string"
            }
        });
    }
};
