using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;

namespace Zoo.Api.Policies
{
    public class ApiHandler : TokenHandler<ApiRequirement>
    {
        public ApiHandler(IConfiguration configuration) : base(configuration) { }

        /// <summary>
        /// Handle api policy requirement
        /// </summary>
        /// <param name="context"></param>
        /// <param name="requirement"></param>
        /// <exception cref="Exception"></exception>
        protected override async Task HandleRequirementAsync(
            AuthorizationHandlerContext context,
            ApiRequirement requirement)
            => ValidateToken(context, requirement, tokenName: "Api");
    }
}