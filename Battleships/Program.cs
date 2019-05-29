using Battleships.Factories;
using System;

namespace Battleships
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("-=Battleships=-");
            Console.WriteLine("Enter coordinates of the form “A5”, where “A” is the column and “5” is the row, to specify a square to target. Shots result in hits, misses or sinks. The game ends when all ships are sunk.");

            var gameFactory = new GameFactory(new RandomBoardFactory(), new ShipFactory());
            var game = gameFactory.Create();

            //main game loop
            while (!game.IsFinished)
            {
                Console.WriteLine(game.Shoot(Console.ReadLine()));
            }

            Console.WriteLine("Game over");
        }
    }
}
