using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Zoo.Core.Enums;
using Zoo.Core.Models;
using Zoo.Core.Repositories;

namespace Zoo.Data.Repositories
{
    public class GiraffeRepository : IGiraffeRepository
    {
        /// <inheritdoc />
        public async Task<List<Giraffe>> GetAllAsync()
        {
            // Normally, you would connect to a database, retrieve data and return that data but for this example
            // we return mock data which we create here.

            // Create list of giraffes
            var giraffes = new List<Giraffe>
            {
                new Giraffe
                {
                    NeckLengthInCm = 210,
                    Name = "Joe",
                    Gender = Gender.Male,
                    Birthday = new DateTime(2009, 2, 16),
                },
                new Giraffe
                {
                    NeckLengthInCm = 194,
                    Name = "Gemima",
                    Gender = Gender.Female,
                    Birthday = new DateTime(2007, 8, 1),
                },
                new Giraffe
                {
                    NeckLengthInCm = 129,
                    Name = "Bob",
                    Gender = Gender.Male,
                    Birthday = new DateTime(2019, 1, 30),
                },
                new Giraffe
                {
                    NeckLengthInCm = 143,
                    Name = "Bob",
                    Gender = Gender.Male,
                    Birthday = new DateTime(2018, 7, 13),
                },
                new Giraffe
                {
                    NeckLengthInCm = 238,
                    Name = "Big Bertha",
                    Gender = Gender.Female,
                    Birthday = new DateTime(2000, 11, 27),
                }
            };

            return giraffes;
        }

        /// <inheritdoc />
        public async Task<Enclosure> GetEnclosureAsync()
        {
            var giraffes = await GetAllAsync();

            // Create enclosure for giraffes
            var enclosure = new Enclosure
            {
                Name = "Giraffe enclosure"
            };

            foreach (var giraffe in giraffes)
                enclosure.AddAnimal(giraffe);

            return enclosure;
        }
    }
}