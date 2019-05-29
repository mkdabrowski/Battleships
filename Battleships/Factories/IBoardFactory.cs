using Battleships.Models;
using Battleships.Models.Ships;
using System.Collections.Generic;

namespace Battleships.Factories
{
    public interface IBoardFactory
    {
        Board Create(int boardSize, IEnumerable<Ship> ships);
    }
}