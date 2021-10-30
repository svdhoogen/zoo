using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Zoo.Api.Policies;
using Zoo.Core.Data;
using Zoo.Core.Services;
using Zoo.Data;
using Zoo.Services;

namespace Zoo.Api.StartupExtensions
{
    public static class ServiceExtension
    {
        public static void AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Create & add database context
            services.AddSingleton(DatabaseContextFactory.CreateDbContext(configuration));

            services.AddSingleton<IAuthorizationHandler, ApiHandler>();
            services.AddSingleton<IAuthorizationHandler, AdminHandler>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<ISeederService, SeederService>();
            services.AddScoped<IZebraService, ZebraService>();
            services.AddScoped<IGiraffeService, GiraffeService>();
        }
    }
}