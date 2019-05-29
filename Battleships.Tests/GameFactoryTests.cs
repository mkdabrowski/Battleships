using Battleships.Factories;
using Battleships.Models;
using Battleships.Models.Ships;
using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;

namespace Battleships.Tests
{
    public class GameFactoryTests
    {
        private IShipFactory _shipFactoryMock;
        private IBoardFactory _boardFactoryMock;

        [SetUp]
        public void SetUp()
        {
            _shipFactoryMock = Substitute.For<IShipFactory>();
            _shipFactoryMock.Create(default).ReturnsForAnyArgs(_ => new TestShip(1));

            _boardFactoryMock = Substitute.For<IBoardFactory>();
            _boardFactoryMock.Create(default, default).ReturnsForAnyArgs(_ => new Board());
        }

        [Test]
        public void Create_Always_ShouldCreateGameWithBoardOfDeclaredSize()
        {
            var sut = new GameFactory(_boardFactoryMock, _shipFactoryMock);

            sut.Create();

            _boardFactoryMock.Received(1).Create(10, Arg.Any<IEnumerable<Ship>>());
        }

        [Test]
        public void Create_Always_ShouldCreateGameWithBoardWithDeclaredShips()
        {
            var sut = new GameFactory(_boardFactoryMock, _shipFactoryMock);

            sut.Create();

            _shipFactoryMock.Received(1).Create(ShipType.Battleship);
            _shipFactoryMock.Received(2).Create(ShipType.Destroyer);
        }
    }
}
