using Battleships.Models.Ships;

namespace Battleships.Factories
{
    public interface IShipFactory
    {
        Ship Create(ShipType shipType);
    }
}