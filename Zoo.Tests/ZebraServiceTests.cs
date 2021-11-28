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
    public class ZebraServiceTests
    {
        private UnitOfWork UnitOfWork { get; set; }
        private ZebraService ZebraService { get; set; }

        private Zebra Zebra { get; set; }

        [SetUp]
        public void Setup()
        {
            // Create unit of work & zebra service
            UnitOfWork = new UnitOfWork(DatabaseContextFactory.CreateDbContext());
            ZebraService = new ZebraService(UnitOfWork);

            // Create zebra
            Zebra = new Zebra
            {
                Name = "Nero",
                Gender = Gender.Female,
                Birthday = new (2012, 5, 5),
                Stripes = 24,
                EnclosureId = 2
            };
        }

        [Test]
        public async Task CRUDTest()
        {
            // Create zebra
            await ZebraService.CreateAsync(Zebra);

            // Detach entity to prevent double tracking errors
            UnitOfWork.DetachEntity(Zebra);

            // Get zebra
            var zebra = await ZebraService.GetAsync(Zebra.Id);

            // Make sure zebra exists
            Assert.IsNotNull(zebra);

            // Check whether all values were set
            Assert.AreEqual(Zebra.Name, zebra.Name);
            Assert.AreEqual(Zebra.Gender, zebra.Gender);
            Assert.AreEqual(Zebra.Birthday, zebra.Birthday);
            Assert.AreEqual(Zebra.Stripes, zebra.Stripes);

            // Get all zebras
            var zebras = await ZebraService.GetAllAsync();

            // Make sure zebra is in list of all zebras
            Assert.IsTrue(zebras.Any(zebra => zebra.Id == Zebra.Id));

            // Update zebra
            zebra.Name = "Nemo";
            await ZebraService.UpdateAsync(zebra);

            UnitOfWork.DetachEntity(zebra);

            // Get zebra
            var updatedZebra = await ZebraService.GetAsync(zebra.Id);

            // Make sure zebra exists
            Assert.IsNotNull(updatedZebra);

            // Check whether all values were updated
            Assert.AreEqual(zebra.Name, updatedZebra.Name);

            // Delete zebra
            await ZebraService.DeleteAsync(zebra.Id);

            Zebra removedZebra = null;

            try
            {
                removedZebra = await ZebraService.GetAsync(zebra.Id);
            }
            catch (InvalidOperationException)
            {
                // We expect an invalid operation exception since it can't find zebra
            }

            // Make sure we didn't find zebra since it has been removed
            Assert.IsNull(removedZebra);

            /*
             If we get here, it means the following methods of ZebraService work as expected:
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