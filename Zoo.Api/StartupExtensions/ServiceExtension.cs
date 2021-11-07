using System;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Zoo.Api.MapperProfiles;
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
            // Get connection string
            var connectionString = configuration.GetSection("ConnectionStrings").GetValue<string>("Zoo");
            if (string.IsNullOrEmpty(connectionString))
                throw new Exception("Cannot get zoo connection string from app settings");

            // Create & add database context
            services.AddDbContext<DatabaseContext>(opt => opt.UseSqlServer(connectionString));

            // Create & add automapper
            services.AddSingleton(CreateMapper());

            services.AddSingleton<IAuthorizationHandler, ApiHandler>();
            services.AddSingleton<IAuthorizationHandler, AdminHandler>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<ISeederService, SeederService>();
            services.AddScoped<IZebraService, ZebraService>();
            services.AddScoped<IGiraffeService, GiraffeService>();
        }

        /// <summary>
        /// Creates, configure & return auto mapper instance.
        /// </summary>
        /// <returns></returns>
        private static IMapper CreateMapper()
        {
            // Create auto mapper config
            var mapperConfig = new MapperConfiguration(config =>
            {
                config.AddProfile(new ZebraProfile());
            });

            // Create mapper instance
            return mapperConfig.CreateMapper();
        }
    }
}