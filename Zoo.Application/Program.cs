using System;
using System.Threading.Tasks;
using Zoo.Core;
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
        /// This method is a workaround for not being able to use async on main
        /// </summary>
        /// <param name="args"></param>
        private static async Task MainAsync(string[] args)
        {
            // Normally, you would automatically handle this with service injection,
            // but I'm too lazy to implement that right now :)
            IUnitOfWork unitOfWork = new UnitOfWork();
            var zebraService = new ZebraService(unitOfWork);
            var giraffeService = new GiraffeService(unitOfWork);

            // Get zebras & giraffes
            var zebras = await zebraService.GetAllAsync();
            var giraffes = await giraffeService.GetAllAsync();

            // Log some info about zebras and giraffes

            Console.WriteLine($"\nZebras: {zebras.Count}\n");

            foreach (var zebra in zebras)
                Console.Write($"Scientific name: {zebra.ScientificName}" +
                              $"\nName: {zebra.Name}" +
                              $"\nAge: {zebra.Age}\n\n");

            Console.WriteLine($"Giraffes: {giraffes.Count}\n");

            foreach (var giraffe in giraffes)
                Console.Write($"Scientific name: {giraffe.ScientificName}" +
                              $"\nName: {giraffe.Name}" +
                              $"\nAge: {giraffe.Age}\n\n");
        }
    }
}