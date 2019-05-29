using Battleships.Factories;
using Battleships.Models.Ships;
using FluentAssertions;
using NUnit.Framework;
using System;

namespace Battleships.Tests
{
    public class ShipFactoryTests
    {
        private IShipFactory _sut;

        [SetUp]
        public void SetUp()
        {
            _sut = new ShipFactory();
        }

        [TestCase(ShipType.Battleship, typeof(Battleship), 5)]
        [TestCase(ShipType.Destroyer, typeof(Destroyer), 4)]
        public void Create_ShipType_ShouldCreateCorrectTypeOfShip(ShipType shipType, Type expectedType, int expectedSize)
        {
            var result = _sut.Create(shipType);

            result.Should().BeOfType(expectedType);
            result.Size.Should().Be(expectedSize);
        }

        [Test]
        public void Create_UnknownShipType_ShouldThrowException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => _sut.Create((ShipType)(-1)));
        }

        [TestCase(ShipType.Battleship)]
        [TestCase(ShipType.Destroyer)]
        public void Create_ShipType_ShouldCreateUnhitShip(ShipType shipType)
        {
            var result = _sut.Create(shipType);

            result.Hits.Should().Be(0);
        }
    }
}
