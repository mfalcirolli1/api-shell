using Castle.Core.Configuration;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;

namespace APIShell.Core
{
    public class AuthenticationMiddleware
    {
        private readonly RequestDelegate next;

        public AuthenticationMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context, IAuthenticationService userManager)
        {
            try
            {
                string apiKey = context.Request.Headers["api-key"];
                string authorizationHeader = context.Request.Headers["Authorization"];
                string jwtToken = string.Empty;

                if (!string.IsNullOrEmpty(authorizationHeader))
                {
                    if (authorizationHeader.StartsWith("Bearer", StringComparison.OrdinalIgnoreCase))
                    {
                        jwtToken = authorizationHeader.Substring("Bearer".Length).Trim();
                    }

                    var expireToken = ValidateToken(jwtToken);

                    if (!expireToken)
                    {
                        context.Response.StatusCode = 401;
                        return;
                    }

                    await next.Invoke(context);
                }
                else if (!string.IsNullOrEmpty(apiKey))
                {
                    // DO SOMETHING
                }
                else
                {
                    context.Response.StatusCode = 401;
                    return;
                }
            }
            catch (Exception)
            {
                context.Response.StatusCode = 401;
            }
        }

        public bool ValidateToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtToken = tokenHandler.ReadJwtToken(token);

            if (jwtToken == null)
            {
                return false;
            }

            if (jwtToken.ValidTo <= DateTime.Now)
            {
                return false;
            }

            return true;
        }
    }

    public static class AuthenticationMiddlewareExtensions 
    {
        public static IApplicationBuilder AuthenticationMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<AuthenticationMiddleware>();
        }
    }

}
