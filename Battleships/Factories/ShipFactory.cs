using Battleships.Models.Ships;
using System;

namespace Battleships.Factories
{
    public class ShipFactory : IShipFactory
    {
        public Ship Create(ShipType shipType)
        {
            switch (shipType)
            {
                case ShipType.Battleship:
                    return new Battleship();
                case ShipType.Destroyer:
                    return new Destroyer();
                default:
                    throw new ArgumentOutOfRangeException(nameof(shipType));
            }
        }
    }
}