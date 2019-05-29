using Battleships.Models;

namespace Battleships
{
    public interface IGame
    {
        ShotResult Shoot(string coordinates);
        bool IsFinished { get; }
    }
}