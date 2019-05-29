using Battleships.Models.Ships;

namespace Battleships.Tests
{
    public class TestShip : Ship
    {
        public TestShip(int size) => Size = size;

        public override int Size { get; }
    }
}
