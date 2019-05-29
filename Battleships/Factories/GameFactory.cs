using Battleships.Models.Ships;
using System.Linq;

namespace Battleships.Factories
{
    public class GameFactory
    {
        private readonly IBoardFactory _boardFactory;
        private readonly IShipFactory _shipFactory;

        public GameFactory(IBoardFactory boardFactory, IShipFactory shipFactory)
        {
            _boardFactory = boardFactory;
            _shipFactory = shipFactory;
        }

        public IGame Create()
        {
            const int boardSize = 10;
            var ships = new[] { ShipType.Battleship, ShipType.Destroyer, ShipType.Destroyer }.Select(_shipFactory.Create).ToList();
            var board = _boardFactory.Create(boardSize, ships);

            return new Game(board);
        }
    }
}
