using Lenders.Common;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Primitives;
using System.Security.Claims;

namespace Lenders.Middleware
{
    public class TokenAuthenticationMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IConfiguration _configuration;

        public TokenAuthenticationMiddleware(RequestDelegate next, IConfiguration configuration)
        {
            _next = next;
            _configuration = configuration;
        }

        public async Task Invoke(HttpContext context)
        {

            if (!context.Request.Headers.TryGetValue("X-Token", out var tokenHeader))
            {
                throw new UnauthorizedAccessException(Constants.NotAuthorized);
            }

            if (IsValidToken(tokenHeader.ToString()))
            {
                var claims = new List<Claim>
                    {
                         new Claim(ClaimTypes.Name, "username"),
                    };

                var identity = new ClaimsIdentity(claims, "custom");

                var principal = new ClaimsPrincipal(identity);

                context.User = principal;

            }
            else
            {
                throw new UnauthorizedAccessException(Constants.NotAuthorized);
            }

            await _next(context);
        }

        private bool IsValidToken(string token)
        {
            if (string.IsNullOrEmpty(token) || token != _configuration["SCS_API_KEY"])
                throw new UnauthorizedAccessException(Constants.NotAuthorized);
            return true;
        }
    }
}
