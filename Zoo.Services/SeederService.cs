using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Zoo.Core.Data;
using Zoo.Core.Models;
using Zoo.Core.Services;

namespace Zoo.Services
{
    public class SeederService : ISeederService
    {
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="unitOfWork"></param>
        public SeederService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <inheritdoc />
        public async Task SeedAsync()
        {
            // Get all migrations that need to be seeded
            var migrationsToSeed = await _unitOfWork
                .GetAll<MigrationsHistory>(tracking: true)
                .Where(migration => !migration.IsSeeded)
                .ToListAsync();
            if (!migrationsToSeed.Any())
                return;

            // Get all implementations of ISeeder
            var seederTypes = AppDomain.CurrentDomain
                .GetAssemblies()
                .SelectMany(assembly => assembly.GetTypes())
                .Where(type => type.IsClass &&
                               !type.IsAbstract &&
                               typeof(ISeeder).IsAssignableFrom(type))
                .ToList();

            // Get & run all seeders for migrations, if it crashes we want to abort the whole method
            // since seeders must be ran in order of when the migrations were added
            foreach (var migration in migrationsToSeed)
            {
                // Get migration name (always has format '12345_abcdef, we want to get the alphabetic part)
                var migrationName = migration.MigrationId.Split('_')[1];

                // Get seeders for current migration
                var migrationSeederTypes = seederTypes
                    .Where(type => type.GetCustomAttribute<SeederForMigrationAttribute>()?.MigrationName == migrationName)
                    .ToList();

                // Create instance & run seeder
                foreach (var migrationSeederType in migrationSeederTypes)
                {
                    // Create & run an instance of the seeder
                    var seeder = (ISeeder)Activator.CreateInstance(migrationSeederType);
                    await seeder.SeedAsync(_unitOfWork);
                }

                // Set migration seeded
                migration.IsSeeded = true;

                await _unitOfWork.SaveChangesAsync();
            }
        }
    }
}