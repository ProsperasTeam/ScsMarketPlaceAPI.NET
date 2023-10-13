using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;

public class TokenAuthenticationMiddleware
{
    private readonly RequestDelegate _next;
    private readonly string _expectedToken;

    public TokenAuthenticationMiddleware(RequestDelegate next, string expectedToken)
    {
        _next = next;
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

public class TokenRequirement : IAuthorizationRequirement
{
    public string ExpectedToken { get; }

    public TokenRequirement(string expectedToken)
    {
        ExpectedToken = expectedToken;
    }
}

public class TokenHandler : AuthorizationHandler<TokenRequirement>
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, TokenRequirement requirement)
    {
        if (context.Resource is AuthorizationFilterContext filterContext)
        {
            if (filterContext.HttpContext.Request.Headers.TryGetValue("X-Token", out var tokenHeader) && tokenHeader == requirement.ExpectedToken)
            {
                context.Succeed(requirement);
            }
        }
        return Task.CompletedTask;
    }
}


public class TokenAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
{
    private readonly IConfiguration _configuration;
    public TokenAuthenticationHandler(
        IOptionsMonitor<AuthenticationSchemeOptions> options,
        ILoggerFactory logger,
        UrlEncoder encoder,
        ISystemClock clock,
        IConfiguration configuration)
        : base(options, logger, encoder, clock)
    {
        _configuration = configuration;
    }

    protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        if (!Context.Request.Headers.TryGetValue("X-Token", out var tokenHeader))
        {
            return AuthenticateResult.Fail("Token is missing.");
        }

        string token = tokenHeader.ToString();
        if (string.IsNullOrEmpty(token) || token != _configuration["SCS_API_KEY"]) // Replace with your expected token
        {
            return AuthenticateResult.Fail("Invalid token.");
        }

        var claims = new[]
        {
            new Claim(ClaimTypes.Name, "username"),
            // Add more claims as needed
        };

        var claimsPrincipal = new ClaimsPrincipal();
        var claimsIdentity = new ClaimsIdentity("JWT");
        claimsPrincipal.AddIdentity(claimsIdentity);

        var ticket = new AuthenticationTicket(claimsPrincipal, Scheme.Name);

        return AuthenticateResult.Success(ticket);
        // return AuthenticateResult.Success(new AuthenticationTicket(new ClaimsPrincipal(), Scheme.Name));
    }
}