using System;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using Zoo.Core.Enums;
using Zoo.Core.Models;
using Zoo.Data;
using Zoo.Services;

namespace Zoo.Tests
{
    [TestFixture]
    public class GiraffeServiceTests
    {
        private UnitOfWork UnitOfWork { get; set; }
        private GiraffeService GiraffeService { get; set; }

        private Giraffe Giraffe { get; set; }

        [SetUp]
        public void Setup()
        {
            // Create unit of work & giraffe service
            UnitOfWork = new UnitOfWork(DatabaseContextFactory.CreateDbContext());
            GiraffeService = new GiraffeService(UnitOfWork);

            // Create giraffe
            Giraffe = new Giraffe
            {
                Name = "Joe",
                Gender = Gender.Male,
                Birthday = new (2015, 5, 5),
                NeckLengthInCm = 189,
                EnclosureId = 1
            };
        }

        [Test]
        public async Task CRUDTest()
        {
            // Create giraffe
            await GiraffeService.CreateAsync(Giraffe);

            // Detach entity to prevent double tracking errors
            UnitOfWork.DetachEntity(Giraffe);

            // Get giraffe
            var giraffe = await GiraffeService.GetAsync(Giraffe.Id);

            // Make sure giraffe exists
            Assert.IsNotNull(giraffe);

            // Check whether all values were set
            Assert.AreEqual(Giraffe.Name, giraffe.Name);
            Assert.AreEqual(Giraffe.Gender, giraffe.Gender);
            Assert.AreEqual(Giraffe.Birthday, giraffe.Birthday);
            Assert.AreEqual(Giraffe.NeckLengthInCm, giraffe.NeckLengthInCm);

            // Get all giraffes
            var giraffes = await GiraffeService.GetAllAsync();

            // Make sure giraffe is in list of all giraffes
            Assert.IsTrue(giraffes.Any(giraffe => giraffe.Id == Giraffe.Id));

            // Update giraffe
            giraffe.Name = "Joel";
            giraffe.NeckLengthInCm = 192;
            await GiraffeService.UpdateAsync(giraffe);

            UnitOfWork.DetachEntity(giraffe);

            // Get giraffe
            var updatedGiraffe = await GiraffeService.GetAsync(giraffe.Id);

            // Make sure giraffe exists
            Assert.IsNotNull(updatedGiraffe);

            // Check whether all values were updated
            Assert.AreEqual(giraffe.Name, updatedGiraffe.Name);

            // Delete giraffe
            await GiraffeService.DeleteAsync(giraffe.Id);

            Giraffe removedGiraffe = null;

            try
            {
                removedGiraffe = await GiraffeService.GetAsync(giraffe.Id);
            }
            catch (InvalidOperationException)
            {
                // We expect an invalid operation exception since it can't find giraffe
            }

            // Make sure we didn't find giraffe since it has been removed
            Assert.IsNull(removedGiraffe);

            /*
             If we get here, it means the following methods of GiraffeService work as expected:
             CreateAsync
             GetAsync
             GetAllAsync
             UpdateAsync
             DeleteAsync

             This means great success :D
            */
        }
    }
}