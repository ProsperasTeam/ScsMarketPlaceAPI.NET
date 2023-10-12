using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

// namespace ServiceAPI
// {
public class TokenAuthenticationMiddleware
{
    private readonly RequestDelegate _next;
    private readonly string _expectedToken; // Load the expected token from configuration

    public TokenAuthenticationMiddleware(RequestDelegate next, string expectedToken)
    {
        _next = next ?? throw new ArgumentNullException(nameof(next));
        _expectedToken = expectedToken;
    }

    public async Task Invoke(HttpContext context)
    {
        if (!context.Request.Headers.TryGetValue("X-Token", out var tokenHeader) || tokenHeader != _expectedToken)
        {
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            return;
        }
        await _next(context);
    }
}
// }
