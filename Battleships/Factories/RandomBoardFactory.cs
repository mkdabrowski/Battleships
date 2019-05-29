using Battleships.Models;
using Battleships.Models.Ships;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Battleships.Factories
{
    public class RandomBoardFactory : IBoardFactory
    {
        private readonly Random _random;

        public RandomBoardFactory()
        {
            _random = new Random();
        }

        public Board Create(int boardSize, IEnumerable<Ship> ships)
        {
            if(ships.Any(ship => ship.Size > boardSize))
                throw new ArgumentException("Board size is smaller than biggest ship", nameof(boardSize));

            var board = new Board();

            foreach (var ship in ships)
            {
                IEnumerable<string> coordinates;
                do
                {
                    coordinates = PlaceShip(boardSize, ship);
                }
                while (coordinates.Any(c => board.ContainsKey(c)));

                foreach (var coordinate in coordinates)
                {
                    board.Add(coordinate, ship);
                }
            }

            return board;
        }

        private IEnumerable<string> PlaceShip(int boardSize, Ship ship)
        {
            var horizontal = _random.Next(2) == 0;
            var row = _random.Next(1, boardSize - ship.Size + 1);
            var column = _random.Next(1, boardSize - ship.Size + 1);

            return Enumerable.Range(0, ship.Size).Select(i => $"{ToColumnName(column + (horizontal ? i : 0))}{row + (horizontal ? 0 : i)}");
        }

        private static char ToColumnName(int number)
        {
            //ASCII
            //65-90 -> A-Z 
            return (char)(number + 64);
        }
    }
}
