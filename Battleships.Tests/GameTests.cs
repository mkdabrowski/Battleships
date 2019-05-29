using Battleships.Models;
using FluentAssertions;
using NUnit.Framework;

namespace Battleships.Tests
{
    public class GameTests
    {
        [Test]
        public void Shoot_ShipCoordinates_ShouldReturnAHit()
        {
            var ship = new TestShip(2);
            var board = new Board
            {
                { "A1", ship },
                { "A2", ship }
            };

            var sut = new Game(board);

            var result = sut.Shoot("A1");

            result.Should().Be(ShotResult.Hit);
        }

        [Test]
        public void Shoot_ShipCoordinatesWhichWereHit_ShouldReturnAMiss()
        {
            var ship = new TestShip(2);
            var board = new Board
            {
                { "A1", ship },
                { "A2", ship }
            };

            var sut = new Game(board);

            var result = sut.Shoot("A1");
            result = sut.Shoot("A1");

            result.Should().Be(ShotResult.Miss);
        }

        [Test]
        public void Shoot_FinalHitCoordinates_ShouldReturnASink()
        {
            var ship = new TestShip(1);
            var board = new Board
            {
                { "A1", ship }
            };

            var sut = new Game(board);

            var result = sut.Shoot("A1");

            result.Should().Be(ShotResult.Sink);
        }

        [Test]
        public void Shoot_NoShipCoordinates_ShouldReturnAMiss()
        {
            var ship = new TestShip(1);
            var board = new Board
            {
                { "A1", ship }
            };

            var sut = new Game(board);

            var result = sut.Shoot("B2");

            result.Should().Be(ShotResult.Miss);
        }

        [Test]
        public void IsFinished_AllShipsHaveBeenSunk_ShouldReturnTrue()
        {
            var ship = new TestShip(1);
            var board = new Board
            {
                { "A1", ship }
            };
            var sut = new Game(board);
            sut.Shoot("A1");

            sut.IsFinished.Should().BeTrue();
        }

        [Test]
        public void IsFinished_ShipsStillOnBoard_ShouldReturnFalse()
        {
            var ship = new TestShip(1);
            var board = new Board
            {
                { "A1", ship }
            };

            var sut = new Game(board);

            sut.IsFinished.Should().BeFalse();
        }
    }
}
