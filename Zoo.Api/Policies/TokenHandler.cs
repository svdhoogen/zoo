using System;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace Zoo.Api.Policies
{
    public abstract class TokenHandler<TRequirement> : AuthorizationHandler<TRequirement> where TRequirement : IAuthorizationRequirement
    {
        private readonly IConfiguration _configuration;

        /// <summary>
        /// Constructor
        /// </summary>
        protected TokenHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// Handles validating token for policy requirement
        /// </summary>
        /// <param name="context"></param>
        /// <param name="requirement"></param>
        /// <param name="tokenName"></param>
        protected void ValidateToken(
            AuthorizationHandlerContext context,
            TRequirement requirement,
            string tokenName)
        {
            // Get api access token
            var correctToken = _configuration.GetSection("Tokens").GetValue<string>(tokenName);
            if (string.IsNullOrWhiteSpace(correctToken))
                throw new Exception("Couldn't get api token from app settings");

            // Get http context
            var httpContext = context.Resource as HttpContext;

            // Get token from headers
            httpContext.Request.Headers.TryGetValue($"{tokenName}Token", out var tokens);
            var token = tokens.FirstOrDefault();

            // Check if token exists
            if (token == null)
            {
                Debug.WriteLine("Token not found");

                context.Fail();
            }

            // Validate token against correct token
            if (token == null || correctToken != token)
            {
                Debug.WriteLine("Token is invalid");

                context.Fail();
            }

            context.Succeed(requirement);
        }
    }
}