using System;
using Battleships.Factories;
using Battleships.Models.Ships;
using FluentAssertions;
using NUnit.Framework;
using System.Linq;

namespace Battleships.Tests
{
    public class RandomBoardFactoryTests
    {
        private IBoardFactory _sut;

        [SetUp]
        public void SetUp()
        {
            _sut = new RandomBoardFactory();
        }

        [Test]
        public void Create_ManyShips_ShouldCreateBoardWithManyShips()
        {
            var ships = new[] {new TestShip(1), new TestShip(2), new TestShip(3)};
            var total = ships.Sum(ship => ship.Size);
            var result = _sut.Create(10, ships);

            result.Should().HaveCount(total);
            result.Should().ContainValues(ships);
        }

        [Test]
        public void Create_NoShips_ShouldCreateEmptyBoard()
        {
            var result = _sut.Create(10, Enumerable.Empty<Ship>());

            result.Should().BeEmpty();
        }

        [Test]
        public void Create_OneShip_ShouldCreateBoardWithOneShip()
        {
            var ship = new TestShip(2);
            var result = _sut.Create(10, new[] { ship });

            result.Should().HaveCount(ship.Size);
            foreach (var item in result)
            {
                item.Value.Should().Be(ship);
            }
        }

        [Test]
        public void Create_BoardSizeSmallerThanShip_ShouldThrowException()
        {
            var ship = new TestShip(2);
            Assert.Throws<ArgumentException>(() => _sut.Create(1, new[] {ship}));
        }
    }
}