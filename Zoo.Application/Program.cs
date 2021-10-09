using System;
using System.Linq;
using System.Threading.Tasks;
using Zoo.Core;
using Zoo.Core.Enums;
using Zoo.Core.Services;
using Zoo.Data;
using Zoo.Services;

namespace Zoo
{
    class Program
    {
        private static void Main(string[] args)
        {
            // Workaround for not being able to use await on Main
            var task = MainAsync(args);
            task.Wait();
        }

        /// <summary>
        /// We log information about zebras & giraffes. This method is a workaround for using async method on main.
        /// </summary>
        /// <param name="args"></param>
        private static async Task MainAsync(string[] args)
        {
            // Normally you would  handle this with service injection, but I'm too lazy to implement that right now :)
            IUnitOfWork unitOfWork = new UnitOfWork();
            IZebraService zebraService = new ZebraService(unitOfWork);
            IGiraffeService giraffeService = new GiraffeService(unitOfWork);

            // Get zebras & giraffes
            var zebras = await zebraService.GetAllAsync();
            var giraffes = await giraffeService.GetAllAsync();

            Write($"Total zebras: {zebras.Count}");
            Write($"Scientific name: {zebras.FirstOrDefault()?.ScientificName}");
            Write($"There are {zebras.Count(zebra => zebra.Gender == Gender.Male)} male zebras\n");

            foreach (var zebra in zebras)
            {
                Write($"Name: {zebra.Name}");
                Write($"Age & gender: {zebra.Age}, {zebra.Gender}");
                Write($"Stripes: {zebra.Stripes}\n");
            }

            Write($"Total giraffes: {giraffes.Count}");
            Write($"Scientific name: {giraffes.FirstOrDefault()?.ScientificName}");
            Write($"There are {giraffes.Count(giraffe => giraffe.Gender == Gender.Female)} female zebras\n");

            foreach (var giraffe in giraffes)
            {
                Write($"Name: {giraffe.Name}");
                Write($"Age & gender: {giraffe.Age}, {giraffe.Gender}");
                Write($"Neck length: {giraffe.NeckLengthInCm}\n");
            }
        }

        private static void Write(string content) => Console.WriteLine(content);
    }
}