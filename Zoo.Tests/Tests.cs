using System;
using NUnit.Framework;
using Zoo.Core.Enums;
using Zoo.Core.Models;

namespace Zoo.Tests
{
    [TestFixture]
    public class ZebraTests
    {
        private Zebra _zebra { get; set; }
        private DateTime _birthday { get; } = new DateTime(2015, 5, 5);

        [SetUp]
        public void Setup()
        {
            _zebra = new Zebra(Gender.Male, _birthday, stripes: 24);
        }

        [Test]
        public void TestAge()
        {
            var zebraAge = _zebra.Age;

            // Calculate correct age
            var correctAge = DateTime.UtcNow.Year - _birthday.Year;
            if (_birthday > DateTime.UtcNow.AddYears(-correctAge))
                correctAge--;

            // Make sure zebra age is correct
            Assert.AreEqual(
                zebraAge,
                correctAge,
                $"Zebra is {correctAge} year olds, but zebra age returned {zebraAge}");
        }

        [Test]
        public void TestScientificName()
        {
            var correctScientificName = "Equus quagga";

            // Make sure zebra age is correct
            Assert.AreEqual(
                _zebra.ScientificName.ToLower().Trim(),
                "Equus quagga".ToLower().Trim(),
                $"Correct scientific name for zebra's is {correctScientificName}, " +
                $"but zebra's scientific name is {_zebra.ScientificName}");
        }
    }
}