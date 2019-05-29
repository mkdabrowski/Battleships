namespace Battleships.Models.Ships
{
    public abstract class Ship
    {
        public abstract int Size { get; }

        public int Hits { get; private set; }

        public bool IsSunk => Size == Hits;

        public void Hit()
        {
            if (!IsSunk)
            {
                Hits++;
            }
        }
    }
}
