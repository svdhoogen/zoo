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
                new Zebra(Gender.Male, new DateTime(1998, 2, 24), 25)
                {
                    Name = "Zack"
                },
                new Zebra(Gender.Male, new DateTime(2004, 8, 7), 24)
                {
                    Name = "Ron"
                },
                new Zebra(Gender.Female, new DateTime(2009, 12, 19), 27)
                {
                    Name = "Lacy"
                },
                new Zebra(Gender.Female, new DateTime(2016, 4, 5), 25)
                {
                    Name = "Gloria"
                },
                new Zebra(Gender.Male, new DateTime(1993, 6, 2), 30)
                {
                    Name = "Big Joel"
                },
                new Zebra(Gender.Female, new DateTime(1999, 10, 21), 23)
                {
                    Name = "Emma"
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