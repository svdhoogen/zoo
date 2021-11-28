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
    public class EnclosureServiceTests
    {
        private UnitOfWork UnitOfWork { get; set; }
        private EnclosureService EnclosureService { get; set; }

        private Enclosure Enclosure { get; set; }

        [SetUp]
        public void Setup()
        {
            // Create unit of work & enclosure service
            UnitOfWork = new UnitOfWork(DatabaseContextFactory.CreateDbContext());
            EnclosureService = new EnclosureService(UnitOfWork);

            // Create enclosure
            Enclosure = new Enclosure
            {
                Name = "Test"
            };
        }

        [Test]
        public async Task CRUDTest()
        {
            // Create enclosure
            await EnclosureService.CreateAsync(Enclosure);

            // Detach entity to prevent double tracking errors
            UnitOfWork.DetachEntity(Enclosure);

            // Get enclosure
            var enclosure = await EnclosureService.GetAsync(Enclosure.Id);

            // Make sure enclosure exists
            Assert.IsNotNull(enclosure);

            // Check whether all values were set
            Assert.AreEqual(Enclosure.Name, enclosure.Name);

            // Get all enclosures
            var enclosures = await EnclosureService.GetAllAsync();

            // Make sure enclosure is in list of all enclosures
            Assert.IsTrue(enclosures.Any(enclosure => enclosure.Id == Enclosure.Id));

            // Update enclosure
            enclosure.Name = "Test enclosure";
            await EnclosureService.UpdateAsync(enclosure);

            UnitOfWork.DetachEntity(enclosure);

            // Get enclosure
            var updatedEnclosure = await EnclosureService.GetAsync(enclosure.Id);

            // Make sure enclosure exists
            Assert.IsNotNull(updatedEnclosure);

            // Check whether all values were updated
            Assert.AreEqual(enclosure.Name, updatedEnclosure.Name);

            // Delete enclosure
            await EnclosureService.DeleteAsync(enclosure.Id);

            Enclosure removedEnclosure = null;

            try
            {
                removedEnclosure = await EnclosureService.GetAsync(enclosure.Id);
            }
            catch (InvalidOperationException)
            {
                // We expect an invalid operation exception since it can't find enclosure
            }

            // Make sure we didn't find enclosure since it has been removed
            Assert.IsNull(removedEnclosure);

            /*
             If we get here, it means the following methods of EnclosureService work as expected:
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