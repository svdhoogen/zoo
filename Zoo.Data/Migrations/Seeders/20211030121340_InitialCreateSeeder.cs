using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Zoo.Core.Data;
using Zoo.Core.Enums;
using Zoo.Core.Models;

namespace Zoo.Data.Migrations.Seeders
{
    [SeederForMigration(typeof(InitialCreateMigration))]
    public class InitialCreateSeeder : ISeeder
    {
        public async Task SeedAsync(IUnitOfWork unitOfWork)
        {
            // Make sure no data has been seeded yet
            if (await unitOfWork.GetAll<Zebra>(tracking: false).AnyAsync())
                return;

            // Create zebra enclosure
            var zebraEnclosure = new Enclosure
            {
                Name = "Zebra enclosure"
            };

            // Create giraffe enclosure
            var giraffeEnclosure = new Enclosure
            {
                Name = "Giraffe enclosure"
            };

            // Create list of zebras
            var zebras = new List<Zebra>
            {
                new()
                {
                    Name = "Zack",
                    Gender = Gender.Male,
                    Birthday = new DateTime(1998, 2, 24),
                    Stripes = 25,
                    Enclosure = zebraEnclosure
                },
                new()
                {
                    Name = "Ron",
                    Gender = Gender.Male,
                    Birthday = new DateTime(2004, 8, 7),
                    Stripes = 24,
                    Enclosure = zebraEnclosure
                },
                new()
                {
                    Name = "Lacy",
                    Gender = Gender.Female,
                    Birthday = new DateTime(2009, 12, 19),
                    Stripes = 27,
                    Enclosure = zebraEnclosure
                },
                new()
                {
                    Name = "Gloria",
                    Gender = Gender.Female,
                    Birthday = new DateTime(2016, 4, 5),
                    Stripes = 25,
                    Enclosure = zebraEnclosure
                },
                new()
                {
                    Name = "Big Joel",
                    Gender = Gender.Male,
                    Birthday = new DateTime(1993, 6, 2),
                    Stripes = 30,
                    Enclosure = zebraEnclosure
                },
                new()
                {
                    Name = "Emma",
                    Gender = Gender.Female,
                    Birthday = new DateTime(1999, 10, 21),
                    Stripes = 23,
                    Enclosure = zebraEnclosure
                }
            };

            // Create list of giraffes
            var giraffes = new List<Giraffe>
            {
                new()
                {
                    Name = "Joe",
                    Gender = Gender.Male,
                    Birthday = new DateTime(2009, 2, 16),
                    NeckLengthInCm = 210,
                    Enclosure = giraffeEnclosure
                },
                new()
                {
                    Name = "Gemima",
                    Gender = Gender.Female,
                    Birthday = new DateTime(2007, 8, 1),
                    NeckLengthInCm = 194,
                    Enclosure = giraffeEnclosure
                },
                new()
                {
                    Name = "Bob",
                    Gender = Gender.Male,
                    Birthday = new DateTime(2019, 1, 30),
                    NeckLengthInCm = 129,
                    Enclosure = giraffeEnclosure
                },
                new()
                {
                    Name = "Bob",
                    Gender = Gender.Male,
                    Birthday = new DateTime(2018, 7, 13),
                    NeckLengthInCm = 143,
                    Enclosure = giraffeEnclosure
                },
                new()
                {
                    Name = "Big Bertha",
                    Gender = Gender.Female,
                    Birthday = new DateTime(2000, 11, 27),
                    NeckLengthInCm = 238,
                    Enclosure = giraffeEnclosure
                }
            };

            // Save changes
            await unitOfWork.AddAsync(zebraEnclosure);
            await unitOfWork.AddAsync(giraffeEnclosure);
            await unitOfWork.AddRangeAsync(zebras);
            await unitOfWork.AddRangeAsync(giraffes);
        }
    }
}