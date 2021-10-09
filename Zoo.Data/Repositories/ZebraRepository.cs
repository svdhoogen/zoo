using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Zoo.Core.Enums;
using Zoo.Core.Models;
using Zoo.Core.Repositories;

namespace Zoo.Data.Repositories
{
    public class ZebraRepository : IZebraRepository
    {
        /// <inheritdoc />
        public async Task<List<Zebra>> GetAllAsync()
        {
            // Normally, you would connect to a database, retrieve data and return that data but for this example
            // we return mock data which we create here.

            // Create list of zebras
            var zebras = new List<Zebra>
            {
                new Zebra
                {
                    Stripes = 25,
                    Name = "Zack",
                    Gender = Gender.Male,
                    Birthday = new DateTime(1998, 2, 24),
                },
                new Zebra
                {
                    Stripes = 24,
                    Name = "Ron",
                    Gender = Gender.Male,
                    Birthday = new DateTime(2004, 8, 7),
                },
                new Zebra
                {
                    Stripes = 27,
                    Name = "Lacy",
                    Gender = Gender.Female,
                    Birthday = new DateTime(2009, 12, 19),
                },
                new Zebra
                {
                    Stripes = 25,
                    Name = "Gloria",
                    Gender = Gender.Female,
                    Birthday = new DateTime(2016, 4, 5),
                },
                new Zebra
                {
                    Stripes = 30,
                    Name = "Big Joel",
                    Gender = Gender.Male,
                    Birthday = new DateTime(1993, 6, 2),
                },
                new Zebra
                {
                    Stripes = 23,
                    Name = "Emma",
                    Gender = Gender.Female,
                    Birthday = new DateTime(1999, 10, 21),
                }
            };

            return zebras;
        }

        /// <inheritdoc />
        public async Task<Enclosure> GetEnclosureAsync()
        {
            var zebras = await GetAllAsync();

            // Create enclosure for giraffes
            var enclosure = new Enclosure
            {
                Name = "Zebra enclosure"
            };

            foreach (var zebra in zebras)
                enclosure.AddAnimal(zebra);

            return enclosure;
        }
    }
}