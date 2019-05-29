using Battleships.Models;
using System.Linq;

namespace Battleships
{
    public class Game : IGame
    {
        private readonly Board _board;

        public Game(Board board)
        {
            _board = board;
        }

        public bool IsFinished => !_board.Any();

        public ShotResult Shoot(string coordinates)
        {
            if (_board.TryGetValue(coordinates, out var ship))
            {
                ship.Hit();
                _board.Remove(coordinates);
                return ship.IsSunk ? ShotResult.Sink : ShotResult.Hit;
            }

            return ShotResult.Miss;
        }
    }
}
