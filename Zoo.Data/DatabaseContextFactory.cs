using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Zoo.Data
{
    public class DatabaseContextFactory : IDesignTimeDbContextFactory<DatabaseContext>
    {
        /// <summary>
        /// Creates db context at runtime for dotnet EF CLI.
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public DatabaseContext CreateDbContext(string[] args)
        {
            Console.WriteLine("Creating IConfiguration to read appsettings.Development.json...");

            // Prepare configuration builder
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory()))
                .AddJsonFile("appsettings.Development.json", optional: false)
                .Build();

            // Create db context
            return CreateDbContext(configuration);
        }

        /// <summary>
        /// Create db context
        /// </summary>
        /// <param name="configuration"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static DatabaseContext CreateDbContext(IConfiguration configuration)
        {
            Console.WriteLine("Getting connection string 'Zoo' from 'ConnectionStrings' in app settings...");

            // Get connection string
            var connectionString = configuration.GetSection("ConnectionStrings").GetValue<string>("Zoo");
            if (string.IsNullOrEmpty(connectionString))
                throw new Exception("Cannot get zoo connection string from app settings");

            Console.WriteLine("Creating options builder using sql server with connection string...");

            // Create options builder that uses sql server with connection string
            var optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
            optionsBuilder.UseSqlServer(connectionString);

            Console.WriteLine("Creating DatabaseContext...");

            // Create database context with options
            return new DatabaseContext(optionsBuilder.Options);
        }
    }
}